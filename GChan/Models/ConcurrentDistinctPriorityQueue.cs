using System.Collections.Generic;
using System.Threading;

namespace GChan.Models
{
    /// <summary>
    /// A queue combined with a hashset to only allow distinct items (by hashcode).
    /// Read/Write locks are imeplemented for each operation so it allows concurrent usage (is threadsafe).<br/>
    /// On dequeue the item with the lowest priority value is removed.
    /// </summary>
    public class ConcurrentDistinctPriorityQueue<TElement, TPriority>(LockRecursionPolicy lockRecursionPolicy)
    {
        private readonly PriorityQueue<TElement, TPriority> queue = new();
        private readonly HashSet<TElement> set = [];
        private readonly ReaderWriterLockSlim locker = new(lockRecursionPolicy);

        /// <returns>True if the element is added to the queue, false if the element is already present.</returns>
        public bool Enqueue(TElement item, TPriority priority)
        {
            locker.EnterWriteLock();

            try
            {
                if (set.Add(item)) // Only add if not present in the HashSet
                {
                    queue.Enqueue(item, priority);
                    return true;
                }

                return false;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        public bool TryDequeue(out TElement item, out TPriority priority)
        {
            locker.EnterWriteLock();

            try
            {
                if (queue.TryDequeue(out item, out priority))
                {
                    set.Remove(item);
                    return true;
                }

                item = default;
                return false;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        public bool Contains(TElement item)
        {
            locker.EnterReadLock();

            try
            {
                return set.Contains(item);
            }
            finally
            {
                locker.ExitReadLock();
            }
        }

        public int Count
        {
            get
            {
                locker.EnterReadLock();

                try
                {
                    return queue.Count;
                }
                finally
                {
                    locker.ExitReadLock();
                }
            }
        }

        public void Clear()
        {
            locker.EnterWriteLock();

            try
            {
                queue.Clear();
                set.Clear();
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
