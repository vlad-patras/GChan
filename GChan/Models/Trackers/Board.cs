using GChan.Data.Models;
using GChan.Forms;
using GChan.Properties;
using GChan.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Models.Trackers
{
    public abstract class Board : Tracker, IProcessable, INotifyPropertyChanged
    {
        private int threadCount;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ThreadCount { get => threadCount; set { threadCount = value; NotifyPropertyChanged(); } }

        /// <summary>
        /// The greatest Thread ID added to tracking.<br/>
        /// This is used to ignore old thread ids in <see cref="ProcessAsync"/>.
        /// </summary>
        public long GreatestThreadId { get; set; }

        public bool ShouldProcess => !cancellationTokenSource.IsCancellationRequested;

        public DateTimeOffset? ReadyToProcessAt => LastScrape + TimeSpan.FromSeconds(Settings.Default.MinSecondsBetweenScrapes);

        public ProcessPriority Priority => ProcessPriority.Default;

        protected Board(string url) : base(url)
        {
            Type = Type.Board;
            
        }

        protected Board(BoardData data) : base($"https://boards.4chan.org/{data.Code}/")
        {
            this.LastScrape = data.LastScrape;
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
#if DEBUG
            logger.Trace($"NotifyPropertyChanged! Board.{propertyName}.");
#endif
            MainForm.StaticInvoke(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }

        public async Task<ProcessResult> ProcessAsync(ProcessableParams parameters, CancellationToken cancellationToken)
        {
            var threads = await GetThreadsImpl(cancellationToken);

            LastScrape = DateTimeOffset.Now;

            if (threads == null)
            {
                return new(removeFromQueue: false);
            }

            ThreadCount = threads.Length;

            var newThreads = threads.Where(t => t.Id > GreatestThreadId).ToArray();

            if (newThreads.Any())
            {
                GreatestThreadId = newThreads.Max(t => t.Id);
            }

            return new(removeFromQueue: false, newProcessables: newThreads);
        }

        /// <summary>
        /// May return null if threads have not been modified since last scrape.
        /// </summary>
        protected abstract Task<Thread[]?> GetThreadsImpl(CancellationToken cancellationToken);

        public override string ToString()
        {
            return $"{SiteDisplayName} - /{BoardCode}/ - ({ThreadCount} Threads)";
        }

        new public ValueTask DisposeAsync() => base.DisposeAsync();
    }
}