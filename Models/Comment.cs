using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models;

public class Comment : IEntity
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string UserComment { get; set; } = null!;
    public int? UserProfileId { get; set; }

}
