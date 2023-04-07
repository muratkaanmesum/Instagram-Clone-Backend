using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.FollowerDal;

public interface IFollowerDal:IEFentityRepository<Follower>
{
    public Task<Follower> AddFollower(Follower follower);
    public Task<ICollection<GetUserFollowerDto>> GetUserFollowers(int id);
}