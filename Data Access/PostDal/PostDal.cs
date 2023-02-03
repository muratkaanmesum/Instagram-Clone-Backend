using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.PostDal;

public class PostDal:EFentityRepository<Post,InstagramCloneContext>,IPostDal
{
    public List<Post> GetPostList(Expression<Func<Post, bool>>? filter = null)
    {
        using var context = new InstagramCloneContext();
        var posts = context.Posts.Where(filter).Include(post => post.Likes).Include(p => p.Comments).ToList();
        if (posts != null)
            return posts;
        posts = context.Posts.Include(post => post.Likes).Include(p => p.Comments).ToList();
        return posts;
    }
}