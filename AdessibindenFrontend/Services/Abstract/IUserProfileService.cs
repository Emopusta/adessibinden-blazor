using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.UserProfiles.Commands.Create;
using Core.Application.Dtos;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IUserProfileService
    {
        public Task<IRequestResult<CreatedUserProfileResponse>> CreateProfile(CreateUserProfileDto createUserProfileDto);

    }
}
