using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Blazored.LocalStorage;
using Core.Application.Dtos;
using Core.Security.JWT;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Web;

namespace AdessibindenFrontend.Services.Concrete
{

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorageService, NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials)
        {

            var response = await _httpClient.PostAsJsonAsync("/api/Auth/Login", credentials);
            var result = response.Content.ReadFromJsonAsync<RequestResult<LoggedResponse>>().Result;
            if (!result.Success) { throw new Exception(result.Error.Detail); }

            await _localStorageService.SetItemAsync("local_token", result.Data.AccessToken);

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLoggedIn(result.Data.AccessToken.Token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.AccessToken.Token);

            NavigateToRecentOrHomePage();

            return result;
        }

        private void NavigateToRecentOrHomePage()
        {
            var absoluteUri = new Uri(_navigationManager.Uri);
            var queryParam = HttpUtility.ParseQueryString(absoluteUri.Query);
            var returnUrl = queryParam["returnUrl"];
            if (string.IsNullOrEmpty(returnUrl))
            {
                _navigationManager.NavigateTo("/");
            }
            else
            {
                _navigationManager.NavigateTo("/" + returnUrl);
            }
        }

        public async Task Logout()
        {
            _ = await _localStorageService.GetItemAsync<AccessToken>("local_token") ?? throw new Exception("You are already logged out.");
            
            await _httpClient.GetAsync("/api/Auth/Logout");

            await _localStorageService.RemoveItemAsync("local_token");

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<IRequestResult<RefreshedTokensResponse>> RefreshToken()
        {
            var response = await _httpClient.GetAsync("/api/Auth/RefreshToken");
            var result = response.Content.ReadFromJsonAsync<RequestResult<RefreshedTokensResponse>>().Result;

            return result;
        }

        public async Task<IRequestResult<RegisteredResponse>> Register(UserForRegisterDto userForRegisterDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/Register", userForRegisterDto);
            var result = response.Content.ReadFromJsonAsync<RequestResult<RegisteredResponse>>().Result;
            if (!result.Success) { throw new Exception(result.Error.Detail); }

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLoggedIn(result.Data.AccessToken.Token);

            await _localStorageService.SetItemAsync("local_token", result.Data.AccessToken);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.AccessToken.Token);

            NavigateToRecentOrHomePage();

            return result;
        }

        public Task<RevokedTokenResponse> RevokeToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCurrentUserId()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var currentUserId = Int32.Parse(authState.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return currentUserId;
        }
        public async Task<string> GetCurrentUserEmail()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User.FindFirst("Email").Value;
        }
    }

   
}
