using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Code { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        [Compare("Password")]
        public string ConfirmPassword{ get; set; }
    }
}
