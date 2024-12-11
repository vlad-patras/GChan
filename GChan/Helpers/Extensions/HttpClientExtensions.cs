using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Helpers.Extensions
{
    public static class HttpClientExtensions
    {
        /// <returns><c>null</c> if <see cref="HttpResponseMessage.StatusCode"/> is <see cref="HttpStatusCode.NotModified"/>.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        public static async Task<string> GetStringAsync(
            this HttpClient client,
            string requestUri,
            DateTimeOffset? ifModifiedSince,
            CancellationToken cancellationToken
        )
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUri),
                Method = HttpMethod.Get,
                Headers =
                {
                    IfModifiedSince = ifModifiedSince,
                },
            };

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
