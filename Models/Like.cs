using System.ComponentModel.DataAnnotations.Schema;
using Instagram_Clone_Backend.Models;

public class Like
{
    public int Id { get; set; }
    [ForeignKey("Posts")]
    public int PostId { get; set; }
    [ForeignKey("UserProfile")]
    public int ProfileId { get; set; }

}