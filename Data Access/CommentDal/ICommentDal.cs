using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.CommentDal;

public interface ICommentDal:IEFentityRepository<Comment>
{
    public List<Comment> GetUserComment(int id);
}