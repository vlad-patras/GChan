using GChan.Forms;
using GChan.Helpers.Extensions;
using GChan.Properties;
using GChan.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CancellationToken = System.Threading.CancellationToken;

namespace GChan.Models.Trackers
{
    /// <summary>
    /// <see cref="IDownloadable{T}"/> implementation is for downloading the website HTML.<br/>
    /// For downloading images <see cref="ScrapeUploadedAssets"/> is used and results queued into a download manager.
    /// </summary>
    public abstract class Thread : Tracker, IProcessable, INotifyPropertyChanged
    {
        public const string NO_SUBJECT = "No Subject";

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Assets that no longer need to be put in processing. This should load the saved assets from the database.
        /// </summary>
        public AssetIdsCollection SeenAssetIds { get; protected init; } = [];

        /// <summary>
        /// Assets that have successfully completed processing. This should be saved in the database.
        /// </summary>
        public AssetIdsCollection SavedAssetIds { get; protected init; } = [];

        public bool ShouldProcess => !Gone && !cancellationTokenSource.IsCancellationRequested;

        public DateTimeOffset? ReadyToProcessAt => LastScrape + TimeSpan.FromSeconds(Settings.Default.MinSecondsBetweenScrapes);

        public ProcessPriority Priority { get; protected set; } = ProcessPriority.Default;

        /// <summary>
        /// Subject for GUI display purposes.<br/>
        /// Displays "Loading..." if thread has not yet been scraped, displays "No Subject" if subject is null.
        /// </summary>
        public string Subject
        {
            get => hasScraped ? subject ?? NO_SUBJECT : "Loading...";
            set
            {
                var update = subject != value;
                subject = value;

                if (update)
                {
                    MainForm.StaticInvoke(() => NotifyPropertyChanged());
                }
            }
        }

        /// <summary>
        /// The identifier of the thread (AKA No. (number))
        /// </summary>
        public long Id { get; protected set; }

        public int? FileCount
        {
            get => fileCount;
            set
            {
                var update = fileCount != value;
                fileCount = value;

                if (update)
                {
                    MainForm.StaticInvoke(() => NotifyPropertyChanged());
                }
            }
        }

        public bool Gone { get; protected set; } = false;

        /// <summary>
        /// Internal representation of subject, may or may not be the subject. Could be username, thread body text, or the GChan user's custom entry.
        /// </summary>
        internal string? subject { get; private set; } = null;
        private int? fileCount = null;

        private bool hasScraped => fileCount != null || subject != null;

        protected Thread(string url, ProcessPriority priority = ProcessPriority.Default) : base(url)
        {
            Type = Type.Thread;
            Priority = priority;

            if (url.Contains("?"))
            {
                //TODO: Do this with Regex or Uri and HTTPUtility HttpUtility.ParseQueryString (https://stackoverflow.com/a/659929/8306962)
                subject = url.Substring(url.LastIndexOf('=') + 1).Replace('_', ' ');
                Url = url.Substring(0, url.LastIndexOf('/'));
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
#if DEBUG
            logger.Trace($"NotifyPropertyChanged! Thread.{propertyName}.");
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<ProcessResult> ProcessAsync(ProcessableParams parameters, CancellationToken cancellationToken)
        {
            if (!ShouldProcess)
            {
                return new(removeFromQueue: true);
            }

            ThreadScrapeResults results;
            try
            {
                results = await ScrapeThreadImpl(
                    Settings.Default.SaveHtml,
                    Settings.Default.SaveThumbnails,
                    cancellationToken
                );
            }
            catch (HttpRequestException ex) when (ex.IsGone())
            {
                await parameters.Hooks.ThreadRemoveSelf(this);
                return new(removeFromQueue: true);
            }

            LastScrape = DateTimeOffset.Now;

            if (results == null)
            {
                return new(removeFromQueue: false);
            }

            if (!string.IsNullOrWhiteSpace(results.ThreadHtml))
            {
                Directory.CreateDirectory(SaveTo);
                var path = Path.Combine(SaveTo, "Thread.html");
                await Utils.WriteAllTextAsync(path, results.ThreadHtml, cancellationToken);
            }

            var assets = results.Uploads.Concat<IAsset>(results.Thumbnails).ToArray();
            var newAssets = assets.Where(a => !SeenAssetIds.Contains(a.Id)).ToArray();

            FileCount = results.Uploads.Length;
            SeenAssetIds.AddRange(newAssets);
            Priority = ProcessPriority.Default; // Set priority to default. May have been set to "high" if thread was new.

            return new(removeFromQueue: false, newProcessables: newAssets);
        }

        /// <summary>
        /// Website specific implementation for scraping a thread, returning html, uploads and thumbnail assets.<br/>
        /// Can return null to indicate the thread has had no change sice <see cref="Tracker.LastScrape"/>.
        /// </summary>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TooManyRequestsException"/>
        protected abstract Task<ThreadScrapeResults> ScrapeThreadImpl(
            bool saveHtml,
            bool saveThumbnails,
            CancellationToken cancellationToken
        );

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 3;
                hash = hash * 13 + Site.GetHashCode();
                hash = hash * 13 + BoardCode.GetHashCode();
                hash = hash * 13 + Id.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"Thread {{ {Site}.{Id} }}";
        }

        new public ValueTask DisposeAsync() => base.DisposeAsync();
    }
}
