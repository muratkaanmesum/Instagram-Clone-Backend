using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models
{
    public class UserProfile:IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Bio { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl{ get; set; }
        public List<Post>? Posts{ get; set; }
        public List<Comment>? Comment { get; set; }
        public List<Story> Stories{ get; set; }
    }

}
