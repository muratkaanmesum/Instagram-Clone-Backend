using System.ComponentModel.DataAnnotations.Schema;
using Instagram_Clone_Backend.Models;

public class Like:IEntity
{
    public int Id { get; set; }
    public int PostId { get; set; }
    [ForeignKey("UserProfile")]
    public int UserProfileId { get; set; }
}