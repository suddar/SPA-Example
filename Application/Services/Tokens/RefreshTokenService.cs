using Domain.Tokens;

namespace Application.Services.Tokens
{
    public class RefreshTokenService
    {
        private TokenService _tokenService;
        public RefreshTokenService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public RefreshToken GenerateToken()
        {
            return new RefreshToken();
        }

        public bool Validate(string refrestToken)
        {
            return true;
        }
    }
}
