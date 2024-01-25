using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses
{
    public class RevokedTokenResponse : IResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public RevokedTokenResponse()
        {
            Token = string.Empty;
        }

        public RevokedTokenResponse(int id, string token)
        {
            Id = id;
            Token = token;
        }
    }
}
