using System.ComponentModel.DataAnnotations.Schema;

namespace TiktokApi.Entities
{
    public class Follower
    {
        // Id Follower Following
        [Column(TypeName = "varchar(450)")]
        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }


        [ForeignKey(nameof(FlowerUser))]
        public string? FollowerId { get; set; }


        public User User { get; set; }

        public User? FlowerUser { get; set; }
    }
}
