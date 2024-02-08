using System.Security.Claims;
using System.Text.Json;

namespace AdessibindenFrontend.Helpers;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];

        var jsonBytes = ParseBase64WithoutPadding(payload);

        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()))
            .Where(p => !p.Type.Equals(ClaimTypes.Role)));

        var roleClaimKeyValuePair = keyValuePairs.Select(p => p)
            .FirstOrDefault(kvp => kvp.Key.Equals(ClaimTypes.Role));
        if (roleClaimKeyValuePair.Key != null && roleClaimKeyValuePair.Value != null)
        {
            var roles = JsonSerializer.Deserialize<List<string>>(roleClaimKeyValuePair.Value.ToString());
            roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
