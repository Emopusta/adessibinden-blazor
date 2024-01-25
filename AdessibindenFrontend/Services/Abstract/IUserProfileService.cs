using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IUserProfileService
    {
        public Task<IRequestResult<CreatedUserProfileResponse>> CreateProfile(CreateUserProfileDto createUserProfileDto);
        public Task<IRequestResult<UpdatedUserProfileResponse>> UpdateProfile(UpdateUserProfileDto createUserProfileDto);
        public Task<IRequestResult<GetUserProfileResponse>> GetProfile(int userId);

    }
}
