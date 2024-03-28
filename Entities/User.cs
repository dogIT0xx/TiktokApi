using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiktokApi.Entities
{
    public class User : IdentityUser
    {
        //(…, Name, Bio, avatar, tick, followings_count, follower_count, like_count)
        [Column(TypeName = "nvarchar(21)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Bio { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Avatar { get; set; }

        [DefaultValue("false")]
        public bool Tick { get; set; }

        [DefaultValue("0")]
        public int FollowingCount { get; set; }

        [DefaultValue("0")]
        public int FollowerCount { get; set; }

        [DefaultValue("0")]
        public int LikeCount { get; set; }

        public IList<Video> Videos { get; set; }
    }
}
