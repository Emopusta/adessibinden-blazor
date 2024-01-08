using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.Login;
using Application.Features.UserProfiles.Commands.Create;
using System.Net.Http.Json;
using System.Net;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Commands.Dtos;
using Application.Features.UserProfiles.Queries.GetByUserId;
using Application.Features.Auth.Commands.RefreshToken;

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

        public async Task<IRequestResult<GetUserProfileResponse>> GetProfile(int userId)
        {
            var response = await _httpClient.GetAsync($"/api/UserProfiles/getById?UserId={userId}");
            var result = response.Content.ReadFromJsonAsync<RequestResult<GetUserProfileResponse>>().Result;
            return result;
        }

        public async Task<IRequestResult<UpdatedUserProfileResponse>> UpdateProfile(UpdateUserProfileDto updateUserProfileDto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/UserProfiles", updateUserProfileDto);
            var result = response.Content.ReadFromJsonAsync<RequestResult<UpdatedUserProfileResponse>>().Result;
            return result;
        }
    }
}
