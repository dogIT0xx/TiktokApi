using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class SendCodeRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
