using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram_Clone_Backend.Models;

public class Follower:IEntity
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    [ForeignKey("UserProfile")]
    public int FollowerId { get; set; }
    public UserProfile FollowerProfile { get; set; }
}