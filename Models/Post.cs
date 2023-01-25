using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models
{
    public class Post : IEntity
    {

        public int Id { get; set; }
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public string? Location { get; set; }
        public string? Caption { get; set; }
        public List<Like>? Likes { get; set; }

    }
}
