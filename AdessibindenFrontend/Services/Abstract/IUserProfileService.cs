﻿using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Results;
using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Queries.GetByUserId;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IUserProfileService
    {
        public Task<IRequestResult<CreatedUserProfileResponse>> CreateProfile(CreateUserProfileDto createUserProfileDto);
        public Task<IRequestResult<UpdatedUserProfileResponse>> UpdateProfile(UpdateUserProfileDto createUserProfileDto);
        public Task<IRequestResult<GetUserProfileResponse>> GetProfile(int userId);

    }
}
