namespace Instagram_Clone_Backend.Models;

public class Comment:IEntity
{
    public int Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public string UserComment { get; set; } = "";
    public Post Post { get; set; }
}