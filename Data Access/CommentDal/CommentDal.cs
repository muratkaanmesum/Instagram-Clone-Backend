using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.CommentDal;

public class CommentDal:EFentityRepository<Comment,InstagramCloneContext>,ICommentDal 
{
    public List<Comment> GetUserComment(int id)
    {
        using var context = new InstagramCloneContext();
        var user = context.Profiles.Find(id);
        if (user == null)
            return new List<Comment>();
        return user.Comment ?? new List<Comment>();
    }

    public new Comment Add(Comment comment)
    {
        using var context = new InstagramCloneContext();
        var user = context.Profiles.Find(comment.ProfileId);
        if (user == null)
            return new Comment();
        context.Comments.Add(comment);
        context.SaveChanges();
        return comment;
    }
}