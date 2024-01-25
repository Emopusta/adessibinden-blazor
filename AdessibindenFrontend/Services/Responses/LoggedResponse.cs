using AdessibindenFrontend.Core.Security;
using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses
{
    public class LoggedResponse : IResponse
    {
        public AccessToken? AccessToken { get; set; }

    }
}
