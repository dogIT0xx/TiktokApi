using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TiktokApi.DTOs.Request
{
    public class UploadVideoRequest
    {
        [Required]
        public string AuthorId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        public IFormFile VideoSrc { get; set; }

        public IFormFile SoundTrack { get; set; }
    }
}
