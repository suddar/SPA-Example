using System.ComponentModel.DataAnnotations;

namespace Application.Mappings.Users
{
    public class CreateUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
