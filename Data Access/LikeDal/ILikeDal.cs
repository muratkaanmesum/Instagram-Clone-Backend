namespace Instagram_Clone_Backend.Data_Access.LikeDal;

public interface ILikeDal:IEFentityRepository<Like>
{
    public Task<Like> AddAsync(int postId, int UserProfileId);
    public Task<Like> DeleteAsync(int postId);
}