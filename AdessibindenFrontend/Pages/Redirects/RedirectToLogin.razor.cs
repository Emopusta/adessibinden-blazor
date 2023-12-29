using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AdessibindenFrontend.Pages.Redirects
{
    public partial class RedirectToLogin
    {
        public Task<AuthenticationState> _authState;
        public NavigationManager _navigationManager;

        public RedirectToLogin(Task<AuthenticationState> authState, NavigationManager navigationManager)
        {
            _authState = authState;
            _navigationManager = navigationManager;
        }

        bool isAuthorized { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            var authState = await _authState;

            if (authState.User?.Identity is null || !authState.User.Identity.IsAuthenticated) {

                var returnUrl = _navigationManager.ToBaseRelativePath(_navigationManager.Uri);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    _navigationManager.NavigateTo("login");
                }
                else
                {
                    _navigationManager.NavigateTo($"login?returnUrl={returnUrl}");
                }
            }
            else
            {
                isAuthorized = true;
            }
            
        }
    }
}
