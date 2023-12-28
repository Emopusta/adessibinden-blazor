using AdessibindenFrontend.Services.Abstract;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AdessibindenFrontend.Services.Concrete
{

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials)
        {
            
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/Login", credentials);
            var result = response.Content.ReadFromJsonAsync<RequestResult<LoggedResponse>>().Result;
            if (result.Data != null) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.AccessToken.Token);
            }
            return result;

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
