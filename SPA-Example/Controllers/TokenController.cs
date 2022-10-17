using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPA_Example.Architecture.Application.Services.Tokens;

namespace SPA_Example.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TokenController : ControllerBase
    {
        private AccessTokenService _accessTokenService;
        public TokenController(AccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_accessTokenService.GenerateToken(new UserLoginDto
            {
                Id = Guid.NewGuid(),
                Email = "test@test.com",
                UserName = "test"
            }));
        }

        [HttpPost("validate")]
        public IActionResult Get([FromBody] string token)
        {
            return Ok(_accessTokenService.Validate(token));
        }
    }
}
