using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Dtos;
using Core.Security.JWT;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IAuthService
    {
        public Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials);
        public Task Logout();
        public Task<IRequestResult<RegisteredResponse>> Register(UserForRegisterDto credentials);
        public Task<IRequestResult<RefreshedTokensResponse>> RefreshToken();
        public Task<RevokedTokenResponse> RevokeToken(string refreshToken);

        public Task<string> GetCurrentUserId();
        public Task<string> GetCurrentUserEmail();
    }
}
