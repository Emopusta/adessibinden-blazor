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
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        NavigationManager _navigationManager;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        public async Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials)
        {
            
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/Login", credentials);
            var result = response.Content.ReadFromJsonAsync<RequestResult<LoggedResponse>>().Result;

            if (result.Data != null) {
            await _localStorageService.SetItemAsync("local_token", result.Data.AccessToken);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.AccessToken.Token);
            }

            _navigationManager.NavigateTo("/", true);
            return result;
        }

        public async Task Logout()
        {
            _ = await _localStorageService.GetItemAsync<AccessToken>("local_token") ?? throw new Exception("You are already logged out.");

            await _localStorageService.RemoveItemAsync("local_token");
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public Task<RefreshedTokensResponse> RefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<RegisteredResponse> Register(UserForRegisterDto credentials)
        {
            throw new NotImplementedException();
        }

        public Task<RevokedTokenResponse> RevokeToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }

   
}
