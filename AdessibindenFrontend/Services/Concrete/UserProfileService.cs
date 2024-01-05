using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.Login;
using Application.Features.UserProfiles.Commands.Create;
using System.Net.Http.Json;
using System.Net;

namespace AdessibindenFrontend.Services.Concrete
{
    public class UserProfileService : IUserProfileService
    {
        private readonly HttpClient _httpClient;

        public UserProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IRequestResult<CreatedUserProfileResponse>> CreateProfile(CreateUserProfileDto createUserProfileDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/UserProfiles", createUserProfileDto);
            var result = response.Content.ReadFromJsonAsync<RequestResult<CreatedUserProfileResponse>>().Result;
            return result;
        }
    }
}
