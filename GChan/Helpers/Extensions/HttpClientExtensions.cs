﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Helpers.Extensions
{
    public class StatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public StatusCodeException(HttpStatusCode statusCode) : base($"Unexpected http status code {statusCode}.")
        {
            StatusCode = statusCode;
        }
    }

    public static class HttpClientExtensions
    {
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="StatusCodeException"/>
        public static async Task<byte[]> GetByteArrayAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new StatusCodeException(response.StatusCode);
            }

            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }

        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="StatusCodeException"/>
        public static async Task<string> GetStringAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new StatusCodeException(response.StatusCode);
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        /// <returns><c>null</c> if <see cref="HttpResponseMessage.StatusCode"/> is <see cref="HttpStatusCode.NotModified"/>.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="StatusCodeException"/>
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

            if (!response.IsSuccessStatusCode)
            {
                throw new StatusCodeException(response.StatusCode);
            }

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        /// <summary>
        /// Synchronous implementation for use in hacky network request within thread constructor.
        /// </summary>
        public static string ReadAsString(this HttpResponseMessage response)
        {
            using var stream = response.Content.ReadAsStream();
            using var reader = new StreamReader(stream, Encoding.UTF8);

            return reader.ReadToEnd();
        }
    }
}
