using GChan.Exceptions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GChan.Helpers;

/// <summary>
/// A <see cref="HttpMessageHandler"/> that throws exceptions for different http status codes.<br/>
/// <list type="bullet">
/// <item><see cref="TooManyRequestsException"/> is thrown for 429 responses.</item>
/// <item><see cref="HttpRequestException"/> is thrown for all other status codes, via <see cref="HttpResponseMessage.EnsureSuccessStatusCode"/></item>
/// </list>
/// </summary>
public class HttpErrorExceptionThrower : DelegatingHandler
{
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("This project does not intend to use any synchronous networking.");
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        {
            throw new TooManyRequestsException(response);
        }

        response.EnsureSuccessStatusCode();

        return response;
    }
}
