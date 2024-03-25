using AdessibindenFrontend.Services.Dtos;
using AdessibindenFrontend.Services.Responses;
using AdessibindenFrontend.Services.Results;

namespace AdessibindenFrontend.Services.Abstract;
public interface IAuthService
{
    public Task<IRequestResult<LoggedResponse>> Login(UserForLoginDto credentials);
    public Task Logout();
    public Task<IRequestResult<RegisteredResponse>> Register(UserForRegisterDto credentials);
    public Task<IRequestResult<RefreshedTokensResponse>> RefreshToken();
    public Task<RevokedTokenResponse> RevokeToken(string refreshToken);
    public Task<int> GetCurrentUserId();
    public Task<bool> IsCurrentUserAuthenticated();
    public Task<string> GetCurrentUserEmail();
}
