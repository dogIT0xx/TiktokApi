using System.ComponentModel.DataAnnotations.Schema;

namespace TiktokApi.Entities
{
    public class Following
    {
        // Id Follower Following
        [Column(TypeName = "varchar(450)")]
        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(FollowingUser))]
        public string? FollowingUserId { get; set; }


        public User User { get; set; }

        public User? FollowingUser { get; set; }
    }
}
