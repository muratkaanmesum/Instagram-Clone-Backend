using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.FollowerDal;

public class FollowerDal:EFentityRepository<Follower,InstagramCloneContext>, IFollowerDal
{
    
    public async Task<Follower> AddFollower(Follower follower)
    {
        await  using var context = new InstagramCloneContext();

        await context.Followers.AddAsync(follower);
        await context.SaveChangesAsync();
        return follower;
    }


}