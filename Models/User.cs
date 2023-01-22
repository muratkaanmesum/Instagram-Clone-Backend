using System.ComponentModel.DataAnnotations;

namespace Instagram_Clone_Backend.Models;

public class User:IEntity
{
    [Key]
    public int Id { get; set; }
    [Required] 
    public string Username { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";

    public UserProfile UserProfile { get; set; }
}