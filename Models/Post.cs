using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models
{
    public class Post : IEntity
    {
        public Post()
        {
            CreateDateTime = DateTime.Now;
        }
        public int Id { get; set; }
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public string? Location { get; set; }
        public string? Caption { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
