
using Microsoft.AspNetCore.Components;
using System.Net;

namespace AdessibindenFrontend.Services
{
    public class StatusCodeDelegatingHandler : DelegatingHandler
    {
        NavigationManager _navigationManager;

        public StatusCodeDelegatingHandler(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                _navigationManager.NavigateTo("login");
                
            }
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _navigationManager.NavigateTo("Counter");
                throw new Exception();
                // how to handle exceptions blazor
            }
            return response;
        }

    }
}
