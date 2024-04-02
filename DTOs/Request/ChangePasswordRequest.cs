using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class ChangePasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string OldPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string NewPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        [Compare("NewPassword")]
        public string ConfirmPassword{ get; set; }
    }
}
