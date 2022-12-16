using System.ComponentModel.DataAnnotations;

namespace SPA_Example.Architecture.Application.Mappings.DTObjects.Users
{
    public class CreateUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
