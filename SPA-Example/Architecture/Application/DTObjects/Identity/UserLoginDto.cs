using System.Security.Claims;

namespace SPA_Example.Architecture.Application.DTObjects.Identity
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
