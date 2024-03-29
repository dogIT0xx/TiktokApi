using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiktokApi.Entities
{
    public class Video
    {
        //Id, UserId, Title, Src, UploadedAt, Duration, LikeCount, CommentCount, SoundTrack
        [Column(TypeName = "varchar(450)")]
        public string Id { get; set; }

        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Src { get; set; }

        public DateTime UploadedAt { get; set; }

        public int Duration { get; set; }

        [DefaultValue("0")]
        public int LikeCount { get; set; }

        [DefaultValue("0")]
        public int SaveCount { get; set; }

        [DefaultValue("0")]
        public int CommentCount { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string SoundTrack { get; set; }

        public User Author { get; set; }
    }
}
