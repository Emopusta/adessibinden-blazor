using AdessibindenFrontend.Core.Security;
using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class RefreshedTokensResponse : IResponse
{
    public AccessToken AccessToken { get; set; }

    public RefreshedTokensResponse()
    {
        AccessToken = null!;
    }

    public RefreshedTokensResponse(AccessToken accessToken)
    {
        AccessToken = accessToken;
    }
}
