using GChan.Models;
using GChan.Properties;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Services
{
    /// <summary>
    /// A pool in which tasks can be thrown in at will. Ensures that only <see cref="MaxConcurrentTasks"/> are ever running at once.
    /// </summary>
    public class ProcessPool
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public record Item(IProcessable Processable, ProcessableParams Params, CancellationToken CancellationToken);

        /// <summary>
        /// Listener for when a task completes. That could mean either success or failure.
        /// </summary>
        public delegate void OnComplete(IProcessable processable, Task<ProcessResult> completedTask);

        public int MaxConcurrentTasks => Settings.Default.MaximumConcurrentDownloads;

        /// <summary>Is the task pool currently running at capacity.</summary>
        public bool Full => runningTasks.Count >= MaxConcurrentTasks;

        /// <summary>
        /// For mapping failed tasks back to the processable.<br/>
        /// Using ConditionalWeakTable because it uses weak references on the tasks, and will not require us to cleanup.
        /// </summary>
        private readonly ConditionalWeakTable<Task, IProcessable> taskToProcessableMap = [];
        private readonly ConcurrentQueue<Item> queue = new();
        private readonly ConcurrentHashSet<Task<ProcessResult>> runningTasks = [];
        private readonly OnComplete completionListener;
        private readonly Task task;

        public ProcessPool(OnComplete completionListener)
        {
            this.completionListener = completionListener;

            task = Task.Factory.StartNew(WorkAsync, TaskCreationOptions.LongRunning);
        }

        public void Enqueue(Item item)
        {
            queue.Enqueue(item);
        }

        private async Task WorkAsync()
        {
            while (true)
            {
                // If the MaxConcurrentTasks decreases or increases this should handle it just fine.
                if (runningTasks.Count < MaxConcurrentTasks && MaybeDequeue(out var item))
                {
                    var newTask = item.Processable.ProcessAsync(item.Params, item.CancellationToken);
                    taskToProcessableMap.Add(newTask, item.Processable);
                    runningTasks.Add(newTask);
                }

                if (runningTasks.Count > 0)
                {
                    var firstCompletedTask = await Task.WhenAny(runningTasks);
                    runningTasks.Remove(firstCompletedTask);

                    // If the task throws an exception we don't know what it was, leading to it essentially being lost.
                    if (taskToProcessableMap.TryGetValue(firstCompletedTask, out var processable))
                    {
                        completionListener(processable, firstCompletedTask);
                    }
                    else
                    {
                        logger.Error(firstCompletedTask.Exception, "Was unable to determine a processable for a failed task in the task pool.");
                    }
                }
                else
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }

        private bool MaybeDequeue(out Item item)
        {
            return queue.TryDequeue(out item);
        }
    }
}
