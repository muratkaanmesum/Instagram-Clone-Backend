using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.CommentDal;

public class CommentDal : EFentityRepository<Comment, InstagramCloneContext>, ICommentDal
{
    public async Task<IEnumerable<Comment>> GetUserCommentAsync(int id)
    {
        using var context = new InstagramCloneContext();
        var user = await context.Profiles.Include(p => p.Comments).FirstOrDefaultAsync(user => user.Id == id);
        if (user == null)
            return new List<Comment>();
        return user.Comments.ToList();
    }

    public new Comment Add(Comment comment)
    {
        using var context = new InstagramCloneContext();
        //var user = context.Profiles.Find(comment.Profile.Id);
        //if (user == null)
        //    return new Comment();
        context.Comments.Add(comment);
        context.SaveChanges();
        return comment;
    }


}