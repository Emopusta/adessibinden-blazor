using AdessibindenFrontend.Services.Results;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Core.Application.Dtos;

namespace AdessibindenFrontend.Services.Abstract
{
    public interface IAuthService
    {
        public Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials);
        public Task<RegisteredResponse> Register(UserForRegisterDto credentials);
        public Task<RefreshedTokensResponse> RefreshToken();
        public Task<RevokedTokenResponse> RevokeToken(string refreshToken);
    }
}
