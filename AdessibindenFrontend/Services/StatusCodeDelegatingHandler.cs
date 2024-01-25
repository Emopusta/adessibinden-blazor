using AdessibindenFrontend.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net;

namespace AdessibindenFrontend.Services
{
    public class StatusCodeDelegatingHandler : DelegatingHandler
    {
        NavigationManager _navigationManager;
        private readonly IJSRuntime _jsRuntime;

        public StatusCodeDelegatingHandler(NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            _navigationManager = navigationManager;
            _jsRuntime = jsRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                await IJSRuntimeExtension.ToastrError(_jsRuntime, "You need to login.");
                _navigationManager.NavigateTo("login");
                throw new Exception("Unauthorized");
            }
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                await IJSRuntimeExtension.ToastrError(_jsRuntime,"You are not authorized");
                throw new Exception("Forbidden");
            }
            return response;
        }

    }
}
