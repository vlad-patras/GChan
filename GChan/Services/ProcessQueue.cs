using GChan.Models;
using GChan.Models.Trackers;
using GChan.Properties;
using Nito.AsyncEx;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace GChan.Services
{
    /// <summary>
    /// A queue for <see cref="IProcessable"/>s. Controls how often they are started.
    /// </summary>
    public class ProcessQueue
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly ConcurrentDistinctQueue<IProcessable> highPriorityQueue = new(LockRecursionPolicy.SupportsRecursion);
        private readonly ConcurrentDistinctQueue<IProcessable> defaultPriorityQueue = new(LockRecursionPolicy.SupportsRecursion);
        private readonly ConcurrentDistinctQueue<IProcessable> lowPriorityQueue = new(LockRecursionPolicy.SupportsRecursion);
        private readonly AsyncManualResetEvent trackerAddedSignal = new();
        private readonly AsyncManualResetEvent resumeSignal = new();
        private readonly TaskPool<ProcessResult> pool;
        private readonly Task task;
        private bool pause;

        private readonly Action<Tracker> addTrackerCallback;
        private readonly CancellationToken shutdownCancellationToken;
        private readonly ProcessableParams processableParams;

        public event Action? PausedPropertyChanged;

        public bool Pause
        {
            get => pause;
            set
            {
                var raiseEvent = pause != value;    // Only raise event if new value is different.

                pause = value;

                if (!pause)
                {
                    resumeSignal.Set();
                }

                if (raiseEvent)
                {
                    PausedPropertyChanged?.Invoke();
                }
            }
        }

        public ProcessQueue(
            IProcessableHooks hooks,
            Action<Tracker> addTrackerCallback,
            CancellationToken shutdownCancellationToken
        )
        {
            this.addTrackerCallback = addTrackerCallback;
            this.shutdownCancellationToken = shutdownCancellationToken;
            this.processableParams = new(hooks);

            this.pool = new(HandleResult);
            this.task = Task.Factory.StartNew(WorkAsync, TaskCreationOptions.LongRunning);
        }

        public void Enqueue(IProcessable processable)
        {
            var wasQueued = processable.Priority switch
            {
                ProcessPriority.High => highPriorityQueue.Enqueue(processable),
                ProcessPriority.Default => defaultPriorityQueue.Enqueue(processable),
                ProcessPriority.Low => lowPriorityQueue.Enqueue(processable),
                _ => throw new InvalidOperationException($"Unknown process priority {processable.Priority}.")
            };

            trackerAddedSignal.Set();
        }

        public async Task WorkAsync()
        {
            while (!shutdownCancellationToken.IsCancellationRequested)
            {
                if (Pause)
                {
                    // If paused wait on the resume signal until it is set.
                    await resumeSignal.WaitAsync();
                    resumeSignal.Reset();   // Reset it in case pause is used again later.
                }

                var item = MaybeDequeue();

                if (item != null)
                {
                    var combinedToken = Utils.CombineCancellationTokens(shutdownCancellationToken, item.CancellationToken);

                    logger.Debug("Adding processable to process pool: {processable}.", item);
                    
                    pool.Enqueue(async () => await item.ProcessAsync(processableParams, combinedToken));
                }

                if (item == null)
                {
                    await Task.WhenAny(
                        Task.Delay(TimeSpan.FromSeconds(15)),
                        trackerAddedSignal.WaitAsync()
                    );

                    trackerAddedSignal.Reset();
                }
                else if (Settings.Default.Max1RequestPerSecond)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }

        /// <summary>
        /// Dequeues processables until one is found that desires being processed, or the queue is depleted (returns null).
        /// </summary>
        private IProcessable? MaybeDequeue()
        {
            var processable = DequeueFrom(highPriorityQueue) ?? DequeueFrom(defaultPriorityQueue) ?? DequeueFrom(lowPriorityQueue);

            if (processable == null)
            {
                logger.Trace("Processable queues contained none or no ready to process items.");
            }

            return processable;
        }

        private void HandleResult(ProcessResult result)
        {
            if (!result.RemoveFromQueue)
            {
                Enqueue(result.Processable);

                logger.Debug("Requeuing processable: {processable}.", result.Processable);
            }
            
            foreach (var newProcessable in result.NewProcessables)
            {
                // Board may return new threads as processables.
                if (newProcessable is Tracker tracker)
                {
                    addTrackerCallback(tracker);    // The callback will enqueue the tracker.
                }
                else
                {
                    Enqueue(newProcessable);
                }
            }
        }

        private static IProcessable? DequeueFrom(ConcurrentDistinctQueue<IProcessable> queue)
        {
            var deferredProcessables = new List<IProcessable>();

            try
            {
                while (true)
                {
                    if (queue.TryDequeue(out var processable))
                    {
                        if (processable.ShouldProcess)
                        {
                            if (processable.ReadyToProcessAt == null || processable.ReadyToProcessAt <= DateTimeOffset.Now)
                            {
                                logger.Trace("Dequeued processable {0}.", processable);
                                return processable;
                            }
                            else
                            {
                                logger.Trace("Deferring processable {0}. Ready to process at {1}.", processable, processable.ReadyToProcessAt);
                                deferredProcessables.Add(processable);
                            }
                        }
                        else
                        {
                            logger.Trace("Discarding dequeued processable {0}.", processable);
                        }
                    }

                    return null;
                }
            }
            finally
            {
                foreach (var deferredProcessable in deferredProcessables)
                {
                    queue.Enqueue(deferredProcessable);
                }
            }
        }
    }
}
