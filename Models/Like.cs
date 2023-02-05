using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Instagram_Clone_Backend.Models;

public class Like:IEntity
{
    public Like()
    {
        CreateDateTime = DateTime.Now;
    }
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }
    [ForeignKey("UserProfile")]
    public int? UserProfileId { get; set; }
    public UserProfile? UserProfile { get;set; }
    public DateTime CreateDateTime { get; set; }
}