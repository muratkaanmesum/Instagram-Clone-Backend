using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Instagram_Clone_Backend.Models;

public class Like:IEntity
{
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }
    [ForeignKey("UserProfile")]
    public int? UserProfileId { get; set; }
    public UserProfile? UserProfile { get;set; }
}