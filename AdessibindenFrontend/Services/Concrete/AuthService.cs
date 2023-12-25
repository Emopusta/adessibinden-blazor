using AdessibindenFrontend.Helpers.Results;
using AdessibindenFrontend.Services.Abstract;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Application.Features.Colors.Queries.GetAll;
using Core.Application.Dtos;
using Core.Application.Responses;
using System.Net.Http;
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
        public async Task<IDataResult<LoggedResponse>> Login(UserForLoginDto credentials)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Auth/Login", credentials);

            var result = response.Content.ReadFromJsonAsync<LoggedResponse>().Result;
            if (response.IsSuccessStatusCode)
            {
                return new SuccessDataResult<LoggedResponse>(result, "User Logged in.");
            }
            else
            {
                return new ErrorDataResult<LoggedResponse>(result, "Wrong credentials.");
            }
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
