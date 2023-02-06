using Instagram_Clone_Backend.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.LikeDal;

public class LikeDal:EFentityRepository<Like,InstagramCloneContext>,ILikeDal
{
    public async Task<Like> AddAsync(int postId ,int UserProfileId)
    {
        using var context = new InstagramCloneContext();
        var post = await context.Posts.Include(p => p.Likes).SingleOrDefaultAsync(p => p.Id == postId);
        var userLike = post.Likes.SingleOrDefault(l => l.UserProfileId == UserProfileId);
        if (userLike != null)
        {
            return null!;
        }
        var like = new Like()
        {
            PostId = postId,
            UserProfileId = UserProfileId
        };
        await context.Set<Like>().AddAsync(like);
        await context.SaveChangesAsync();
        return like;
    }
}