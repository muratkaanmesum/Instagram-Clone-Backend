using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.PostDal;

public class PostDal:EFentityRepository<Post,InstagramCloneContext>,IPostDal
{
    public async Task<List<Post>> GetPostListAsync(Expression<Func<Post, bool>>? filter = null)
    {
        await using var context = new InstagramCloneContext();
        var posts = await context.Posts.Where(filter)
            .Include(post => post.Likes)
            .Include(p => p.Comments)
            .ToListAsync();
        return posts;
    }

    public async Task<Post> DeleteWithIdAsync(int id)
    {
        await using var context = new InstagramCloneContext();
        var post = await context.Posts.SingleOrDefaultAsync(post => post.Id == id);
        context.Entry(post).State = EntityState.Deleted;
        await context.SaveChangesAsync();
        return post ?? new Post();
    }

    public async Task<Post> UpdateAsync(Post post, int id)
    {
        await using var context = new InstagramCloneContext();
        post.Id = id;
        context.Entry(post).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return post;
    }
}