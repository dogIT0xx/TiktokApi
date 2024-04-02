using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
