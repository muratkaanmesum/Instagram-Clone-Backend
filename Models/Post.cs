using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models
{
    public class Post:IEntity
    {

        public int  Id { get; set; }
        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public string? Location { get; set; }
        public List<UserProfile>? Likes { get; set; }

    }
}
