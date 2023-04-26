using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.FollowerDal;

public class FollowerDal:EFentityRepository<Follower,InstagramCloneContext>, IFollowerDal
{
    
    public async Task<Follower> AddFollower(Follower follower)
    {
        await  using var context = new InstagramCloneContext();

        var followed = await context.Profiles.Include(p => p.Followers).SingleOrDefaultAsync(p => p.Id == follower.UserProfileId);
        var following = await context.Profiles.SingleOrDefaultAsync(p => p.Id == follower.FollowerId);
        if (followed == null || following == null)
            return null;
        var isFollowing = followed.Followers.SingleOrDefault(p => p.FollowerId == following.Id);
        if (isFollowing != null)
            return null;
        follower.UserProfile = followed!;
        follower.FollowerProfile= following!;
        await context.Followers.AddAsync(follower);
        await context.SaveChangesAsync();
        return follower;
    }

    public async Task<ICollection<GetUserFollowerDto>> GetUserFollowers(int id)
    {
        await using var context = new InstagramCloneContext();
        var profile = await context.Profiles.Include(p => p.Followers)
            .ThenInclude(p => p.FollowerProfile)
            .ThenInclude(p => p.User)
            .SingleOrDefaultAsync(profile => profile.Id == id);
        var list = new List<GetUserFollowerDto>();
        foreach (var follower in profile!.Followers)
        {
            list.Add(new GetUserFollowerDto()
            {
                 FollowerId = follower.FollowerId,
                 FullName = follower.FollowerProfile.FullName,
                PictureUrl = "dummy",
                Username = follower.FollowerProfile.User.Username,
            });
        }
        return list;
    }
    public async Task<ICollection<GetUserFollowerDto>> GetUserFollowing(int id)
    {
  await using var context = new InstagramCloneContext();
  var profile = await context.Profiles.Include(p => p.Following).ThenInclude(p => p.UserProfile).ThenInclude(p => p.User).SingleOrDefaultAsync(t => t.Id == id);
        var list = new List<GetUserFollowerDto>();
        foreach (var following in profile!.Following)
        {
            list.Add(new GetUserFollowerDto()
            {
                 FollowerId = following .UserProfileId,
                 FullName = following .UserProfile.FullName,
                PictureUrl = "dummy",
                Username = following .UserProfile.User.Username,
            });
        }
        return list;
    }


}