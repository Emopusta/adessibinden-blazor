
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace AdessibindenFrontend.Services
{
    public class CookieHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
