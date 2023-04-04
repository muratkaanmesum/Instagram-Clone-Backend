using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.CommentDal;

public interface ICommentDal:IEFentityRepository<Comment>
{
    public Task<IEnumerable<Comment>> GetUserCommentAsync(int id);
    public Task<Comment> DeleteWithIdAsync (int id);
    public Task<Comment> UpdateAsync(Comment comment);
    public Task<IEnumerable<Comment>> GetPostCommentsAsync(int id);
}