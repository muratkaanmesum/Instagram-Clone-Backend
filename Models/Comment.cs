using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models;

public class Comment : IEntity
{
    public Comment()
    {
        DateTime = DateTime.Now;
    }
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }
    public string UserComment { get; set; } = null!;
    [ForeignKey("UserProfile")]
    public int? UserProfileId { get; set; }
    public virtual UserProfile? UserProfile { get; set; }
    public DateTime DateTime { get; set; }
}
