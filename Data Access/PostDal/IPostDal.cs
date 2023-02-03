using System.Linq.Expressions;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.PostDal;

public interface IPostDal : IEFentityRepository<Post>
{
     List<Post>? GetPostList(Expression<Func<Post, bool>> filter);
}