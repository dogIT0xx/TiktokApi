using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
