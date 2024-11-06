﻿using GChan.Data.Models;
using GChan.Properties;
using GChan.Services;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GChan.Models.Trackers
{
    // Should contain the subject too (which is available via the catalog API)
    // so the thread doesn't have to do another request to fetch it.
    // Image count is also present on the catalog API too.
    public class BoardScrapeResult
    {
        public string Url { get; set; }
        public long Id { get; set; }
        public long FileCount { get; set; }
        public string Subject { get; set; }

        public BoardScrapeResult(string url, long id, long fileCount, string subject)
        {
            Url = url;
            Id = id;
            FileCount = fileCount;
            Subject = subject;
        }
    }

    public abstract class Board : Tracker, IProcessable
    {
        protected int threadCount;

        public int ThreadCount
        {
            get
            {
                return threadCount;
            }
        }

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

        public async Task<ProcessResult> ProcessAsync(ProcessableParams parameters, CancellationToken cancellationToken)
        {
            try
            {
                var threads = await GetThreadsImpl(cancellationToken);

                LastScrape = DateTimeOffset.Now;

                if (threads == null)
                {
                    return new(this, removeFromQueue: false, newProcessables: []);
                }

                threadCount = threads.Length;

                var newThreads = threads.Where(t => t.Id > GreatestThreadId);

                GreatestThreadId = newThreads.Max(t => t.Id);

                return new(this, removeFromQueue: false, newProcessables: newThreads);
            }
            catch (WebException webEx)
            {
                logger.Error(webEx, "Error occured attempting to get thread links.");

#if DEBUG
                MessageBox.Show("Connection Error: " + webEx.Message);
#endif
            }

            return new(this, removeFromQueue: false);
        }

        /// <summary>
        /// May return null if threads have not been modified since last scrape.
        /// </summary>
        protected abstract Task<Thread[]?> GetThreadsImpl(CancellationToken cancellationToken);

        public override string ToString()
        {
            return $"{SiteDisplayName} - /{BoardCode}/ - ({ThreadCount} Threads)";
        }

        public ValueTask DisposeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}