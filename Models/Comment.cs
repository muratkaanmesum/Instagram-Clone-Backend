using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models;

public class Comment:IEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserProfile")]
    public int ProfileId { get; set; }
    [ForeignKey("Posts")]
    public int PostId { get; set; }
    public string UserComment { get; set; } = "";
    }
