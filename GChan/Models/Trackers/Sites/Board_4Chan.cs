using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GChan.Data.Models;
using GChan.Helpers.Extensions;
using System.Threading;
using System.IO;
using GChan.Properties;

namespace GChan.Models.Trackers.Sites
{
    public class Board_4Chan : Board
    {
        public const string IS_BOARD_REGEX = "boards.(4chan|4channel).org/[a-zA-Z0-9]*?/*$";
        public const string BOARD_CODE_REGEX = "(?<=((chan|channel).org/))[a-zA-Z0-9]+(?=(/))?";

        public Board_4Chan(string url) : base(url)
        {
            this.Site = Site._4chan;

            var boardCodeMatch = Regex.Match(url, BOARD_CODE_REGEX);
            this.BoardCode = boardCodeMatch.Groups[0].Value;
            this.SaveTo = Path.Combine(Settings.Default.SavePath, SiteDisplayName, BoardCode);
        }

        public Board_4Chan(BoardData data) : base(data)
        {
            this.Site = Site._4chan;
            this.BoardCode = data.Code;
            this.GreatestThreadId = data.GreatestThreadId;
            this.SaveTo = Path.Combine(Settings.Default.SavePath, SiteDisplayName, BoardCode);
        }

        public static bool UrlIsBoard(string url)
        {
            return Regex.IsMatch(url, IS_BOARD_REGEX);
        }

        override protected async Task<Thread[]?> GetThreadsImpl(CancellationToken cancellationToken)
        {
            var catalogUrl = "https://a.4cdn.org/" + BoardCode + "/catalog.json";
            var client = Utils.GetHttpClient();
            var json = await client.GetStringAsync(catalogUrl, LastScrape, cancellationToken);

            if (json == null)
            {
                return null;
            }

            var jArray = JArray.Parse(json);

            var threads = jArray
                .SelectTokens("[*].threads[*]")
                .Select(thread =>
                {
                    var id = thread["no"].Value<long>();
                    var url = "https://boards.4chan.org/" + BoardCode + "/thread/" + id;
                    var subject = thread["sub"]?.Value<string>() ?? Thread.NO_SUBJECT;
                    var fileCount = thread["images"].Value<int>();

                    return new Thread_4Chan(url, subject, fileCount);
                })
                .ToArray();

            return threads;
        }
    }
}
