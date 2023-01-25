using System.ComponentModel.DataAnnotations.Schema;

public class Like
{
    public int Id { get; set; }
    [ForeignKey("Posts")]
    public int PostId { get; set; }
    [ForeignKey("UserProfile")]
    public int UserId { get; set; }
}