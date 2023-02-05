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

    public async Task<Comment> DeleteWithIdAsync(int id)
    {
        await using var context = new InstagramCloneContext();
        var comment = await context.Comments.FirstOrDefaultAsync(p => p.Id == id);
        context.Entry(comment).State = EntityState.Deleted;
        await context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        await using var context = new InstagramCloneContext();
        context.Entry(comment).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return comment;
    }

}