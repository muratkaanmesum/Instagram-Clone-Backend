namespace Instagram_Clone_Backend.Models
{
    public class Post
    {

        public int  Id { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public List<UserProfile>? Likes { get; set; }
        public List<UserProfile>? Comments { get; set; }
    }
}
