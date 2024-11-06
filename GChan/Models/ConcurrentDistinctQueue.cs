using System.Collections.Generic;
using System.Threading;

namespace GChan.Models
{
    /// <summary>
    /// A queue combined with a hashset to only allow distinct items (by hashcode).
    /// Read/Write locks are imeplemented for each operation so it allows concurrent usage (is threadsafe).
    /// </summary>
    public class ConcurrentDistinctQueue<T>(LockRecursionPolicy lockRecursionPolicy)
    {
        private readonly Queue<T> queue = new();
        private readonly HashSet<T> set = [];
        private readonly ReaderWriterLockSlim locker = new(lockRecursionPolicy);

        public bool Enqueue(T item)
        {
            locker.EnterWriteLock();

            try
            {
                if (set.Add(item)) // Only add if not present in the HashSet
                {
                    queue.Enqueue(item);
                    return true;
                }

                return false;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        public bool TryDequeue(out T item)
        {
            locker.EnterWriteLock();

            try
            {
                if (queue.TryDequeue(out item))
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

        public bool Contains(T item)
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
