using EFCoreFirstAPI.Misc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCoreFirstAPI.Models.DTOs
{
    public class UserCreateDTO
    {
        [UsernameValidator]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password cannot be empty")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Password pattern worng")]
        [DefaultValue("password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role cannot be empty")]
        public Roles Role { get; set; } 
    }
}
