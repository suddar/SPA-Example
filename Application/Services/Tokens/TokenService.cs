using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Tokens
{
    public class TokenService
    {
        public string GenerateToken(string secretKey, string issuer, string audience, DateTime utcExpirationTime, IEnumerable<Claim>? claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(issuer, audience, claims, DateTime.UtcNow, utcExpirationTime, credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool Validate(string refreshToken, TokenValidationParameters tokenValidationParameters)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new();
                _ = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

