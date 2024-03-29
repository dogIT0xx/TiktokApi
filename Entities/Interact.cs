using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiktokApi.Entities
{
    public class Interact
    {
        [Column(TypeName = "varchar(450)")]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string? VideoId { get; set; }

        [DefaultValue("false")]
        public bool Liked { get; set; }

        [DefaultValue("false")]
        public bool Saved { get; set; }


        public User User { get; set; }

        public Video? Video { get; set; }
    }
}
