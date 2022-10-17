using System.ComponentModel.DataAnnotations;

namespace SPA_Example.Architecture.Application.DTObjects.Users
{
    public class CreateUserDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
