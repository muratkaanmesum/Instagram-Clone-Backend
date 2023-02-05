using System.Linq.Expressions;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.PostDal;

public interface IPostDal : IEFentityRepository<Post>
{
    public Task <List<Post>>? GetPostListAsync(Expression<Func<Post, bool>> filter);
    public Task<Post> DeleteWithIdAsync(int id);
    public Task<Post> UpdateAsync(Post post,int id);
}