using AdessibindenFrontend.Core.Security;
using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class RegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public int UserId { get; set; }
}
