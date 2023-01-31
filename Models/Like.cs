using System.ComponentModel.DataAnnotations.Schema;
using Instagram_Clone_Backend.Models;

public class Like
{
    public int Id { get; set; }
    public int PostId { get; set; }
}