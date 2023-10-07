﻿using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace GChan.Controllers
{
    /// <summary>
    /// Class that manages a file download pool.<br/>
    /// <typeparamref name="T"/> must provide a good implementation of <see cref="object.GetHashCode"/>.
    /// </summary>
    /// <remarks>
    /// TODO: Genericise to accept any class that implements an interface e.g. "IDownloadable".
    /// </remarks>
    public class DownloadManager<T> where T: IDownloadable<T>
    {
        public delegate void SuccessCallback(T item);
        public delegate void FailureCallback(T item, bool retry);

        private const int ConcurrentCount = 25;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly TimeSpan interval = TimeSpan.FromSeconds(1);

        private readonly ConcurrentDictionary<T, Thread> downloading = new();
        private readonly ConcurrentQueue<T> waiting = new();
        private readonly Timer timer;

        public DownloadManager()
        { 
            timer = new(TimerTick, null, interval, interval);
        }

        public void Queue(T item)
        {
            waiting.Enqueue(item);
        }

        public void Queue(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                logger.Log(LogLevel.Info, "Queueing {item} for download.", item);
                waiting.Enqueue(item);
            }
        }

        /// <summary>
        /// A tick of the timer.
        /// </summary>
        /// <param name="_">Unnecessary paramater.</param>
        private void TimerTick(object _)
        {
            var skimCount = ConcurrentCount - downloading.Count;
            var items = Skim(skimCount);
            logger.Log(LogLevel.Info, "Skimming {skim_count} items from queue, got {skim_result_count}.", skimCount, items.Count);

            // TODO: If no images were found in queue set the timer to a slightly longer interval, to stop poll spamming.

            foreach (var image in items)
            {
                var newThread = new Thread(() => image.Download(DownloadComplete, DownloadFailed));
                newThread.Start();
                downloading.TryAdd(image, newThread);
            }
        }

        /// <summary>
        /// Take some items off of the queue.
        /// </summary>
        private List<T> Skim(int amount)
        {
            var chunk = new List<T>(amount);

            while (chunk.Count < amount && waiting.TryDequeue(out var item))
            { 
                chunk.Add(item);
            }

            return chunk;
        }

        /// <summary>
        /// Called when a download has completed successfully.<br/>
        /// Removes <paramref name="item"/> from the downloading dict.
        /// </summary>
        private void DownloadComplete(T item)
        {
            logger.Log(LogLevel.Debug, "Item {item} completed downloading succesfully.", item);
            downloading.TryRemove(item, out var _);
        }

        /// <summary>
        /// Called when a download was unable to complete.<br/>
        /// Removes <paramref name="item"/> from the downloading dict and requeues it pending download.<br/>
        /// If the failure is permanent (e.g. image is gone) then <paramref name="retry"/> can be set to false.
        /// </summary>
        private void DownloadFailed(T item, bool retry)
        {
            logger.Log(LogLevel.Debug, "Item {item} completed downloading succesfully.", item);

            downloading.TryRemove(item, out var _);

            if (retry)
            { 
                waiting.Enqueue(item);
            }
        }
    }
}
