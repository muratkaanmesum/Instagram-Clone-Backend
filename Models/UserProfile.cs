using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models
{
    public class UserProfile : IEntity
    {
        public UserProfile()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
            Stories = new List<Story>();
            Followers = new List<Follower>();
            Following = new List<Follower>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Follower> Following { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Story> Stories { get; set; }
    }

}
