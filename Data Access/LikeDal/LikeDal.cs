using Instagram_Clone_Backend.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.LikeDal;

public class LikeDal:EFentityRepository<Like,InstagramCloneContext>,ILikeDal
{
    public new Like Add(Like like)
    {
        using var context = new InstagramCloneContext();
        var post = context.Posts.Include(e => e.Likes).SingleOrDefault(p => p.Id == like.PostId);
        var postLike = post.Likes.Where(l => l.UserProfileId == like.UserProfileId).ToList();
        if (postLike.Count != 0)
            return null;
        context.Set<Like>().Add(like);
        context.SaveChanges();
        return like;
    }
}