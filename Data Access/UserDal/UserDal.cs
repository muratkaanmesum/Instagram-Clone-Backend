using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public class UserDal : EFentityRepository<User, InstagramCloneContext>, IEFentityRepository<User>, IUserDal
{
    public List<User> GetAllData()
    {
        using var context = new InstagramCloneContext();
        return context.Users.Include(e => e.UserProfile)
            .ThenInclude(e => e.Posts)
            .ThenInclude(p => p.Likes)
            .Include(e => e.UserProfile)
            .ThenInclude(e => e.Comments)
            .Include(e => e.UserProfile)
            .ThenInclude(p => p.Likes)
            .Include(e => e.UserProfile)
            .ThenInclude(p => p.Stories)
            .ToList();
    }
}