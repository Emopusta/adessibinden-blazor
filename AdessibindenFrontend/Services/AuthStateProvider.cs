using AdessibindenFrontend.Helpers;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.RefreshToken;
using Blazored.LocalStorage;
using Core.Security.JWT;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

namespace AdessibindenFrontend.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IAuthService _authService;
        private readonly ILocalStorageService _localStorageService;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, IAuthService authService, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authService = authService;
            _localStorageService = localStorageService;
        }

        //TODO: fix refresh token auto login problem when logout
        public override async Task<AuthenticationState> GetAuthenticationStateAsync() //refactor needed
        {
            var token = await _localStorage.GetItemAsync<string>("local_token");

            if (token != null) {
                var accessToken = JsonConvert.DeserializeObject<AccessToken>(token);

                if (!CheckIsTokenExpired(accessToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken.Token);
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
                }
            }

            var refreshToken = await _authService.RefreshToken();
            if (refreshToken.Success)
                {
                    await _localStorageService.SetItemAsync("local_token", refreshToken.Data.AccessToken);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", refreshToken.Data.AccessToken.Token);
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(refreshToken.Data.AccessToken.Token), "jwtAuthType")));
                }
                
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        
        private bool CheckIsTokenExpired(AccessToken accessToken)
        {
            return accessToken.Expiration < DateTime.UtcNow;
        }

    }
}
