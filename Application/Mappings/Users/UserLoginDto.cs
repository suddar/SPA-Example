using System.Security.Claims;

namespace Application.Mappings.Users
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
