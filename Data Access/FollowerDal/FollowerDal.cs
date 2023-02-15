using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.FollowerDal;

public class FollowerDal:EFentityRepository<Follower,InstagramCloneContext>, IFollowerDal
{
    
    public async Task<Follower> AddFollower(Follower follower)
    {
        await  using var context = new InstagramCloneContext();

        var followed = await context.Profiles.SingleOrDefaultAsync(p => p.Id == follower.UserProfileId);
        var following = await context.Profiles.SingleOrDefaultAsync(p => p.Id == follower.FollowerId);
        follower.UserProfile = followed!;
        follower.FollowerProfile= following!;
        await context.Followers.AddAsync(follower);
        await context.SaveChangesAsync();
        return follower;
    }

    public async Task<ICollection<Follower>> GetUserFollowers(int id)
    {
        await using var context = new InstagramCloneContext();
        var profile = await context.Profiles.SingleOrDefaultAsync(profile => profile.Id == id);
        return profile.Followers.ToList();
    }


}