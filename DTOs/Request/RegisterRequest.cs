using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class RegisterRequest
    {
        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string? Password { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public int VerificationCode{ get; set; }
    }
}
