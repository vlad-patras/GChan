using GChan.Data.Models;
using NLog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Models.Trackers
{
    public enum Type { Board, Thread };

    public abstract class Tracker : IAsyncDisposable
    {
        /// <summary>
        /// Response status codes that indicate content is no longer available.
        /// </summary>
        public static readonly HttpStatusCode?[] GoneStatusCodes =
        {
            HttpStatusCode.NotFound,
            HttpStatusCode.Gone,
        };

        public string Url { get; protected set; }

        public string SaveTo { get; protected set; }

        public Type Type { get; protected set; }

        public Site Site { get; protected set; }

        public string SiteDisplayName => Site.ToString().TrimStart('_');

        /// <summary>
        /// Code for the board this is tracking, excluding slashes.
        /// e.g. gif, r9k, b
        /// </summary>
        public string BoardCode { get; protected set; }

        /// <summary>
        /// When this tracker was last succesfully scraped, null if not yet scraped.<br/>
        /// <see cref="DateTimeOffset"/> because that's what HttpClient header property accepts.
        /// </summary>
        public DateTimeOffset? LastScrape { get; protected set; }

        /// <summary>
        /// Whether or not to keep scraping this tracker.
        /// </summary>
        public bool Scraping => !CancellationToken.IsCancellationRequested;

        public CancellationToken CancellationToken => cancellationTokenSource.Token;

        protected readonly ILogger logger = LogManager.GetCurrentClassLogger();

        protected readonly CancellationTokenSource cancellationTokenSource = new();

        protected Tracker(string url)
        {
            Url = url;
        }

        public override string ToString()
        {
            if (this is Thread thread)
            {
                return $"Thread {{ {Site}, /{BoardCode}/, {thread.Id}, Gone: {thread.Gone} }}";
            }
            else if (this is Board)
            {
                return $"Board {{ {Site}, /{BoardCode}/ }}";
            }
            else
            {
                return $"{GetType().Name} {{ {Site}, /{BoardCode}/ }}";
            }
        }

        public void Cancel()
        {
            cancellationTokenSource.Cancel();
        }

        public ValueTask DisposeAsync()
        {
            cancellationTokenSource.Dispose();
            return default;
        }
    }
}
