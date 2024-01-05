using AdessibindenFrontend.Helpers;
using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.RefreshToken;
using Blazored.LocalStorage;
using Core.Security.JWT;
using Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

namespace AdessibindenFrontend.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
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

            var refreshTokenResponse = await _httpClient.GetAsync("/api/Auth/RefreshToken");
            var refreshToken = refreshTokenResponse.Content.ReadFromJsonAsync<RequestResult<RefreshedTokensResponse>>().Result;
            if (refreshToken.Success)
                {
                    await _localStorage.SetItemAsync("local_token", refreshToken.Data.AccessToken);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", refreshToken.Data.AccessToken.Token);
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(refreshToken.Data.AccessToken.Token), "jwtAuthType")));
                }
                
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        

        public void NotifyUserLoggedIn(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            NotifyAuthenticationStateChanged(authState);
        }
        private bool CheckIsTokenExpired(AccessToken accessToken)
        {
            return accessToken.Expiration < DateTime.UtcNow;
        }


    }
}
