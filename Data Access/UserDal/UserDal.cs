using System.Linq.Expressions;
using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public class UserDal : EFentityRepository<User, InstagramCloneContext>, IEFentityRepository<User>, IUserDal
{
    public async Task<List<User>> GetAllData()
    {
        using var context = new InstagramCloneContext();
        var list = await context.Users.Include(u => u.UserProfile)
            .ThenInclude(p => p.Comments)
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.Posts)
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.Comments)
            .ToListAsync();

        return list;
    }

    public async Task<User>? DeleteByIdAsync(int id)
    {
        using var context = new InstagramCloneContext();
        bool v = await DoesExitsAsync(id);
        if (v == false)
        {
            return null!;
        }

        var user = await context.Users.SingleOrDefaultAsync(user => user.Id == id);
        context.Entry(user).State = EntityState.Deleted;
        await context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Update(User user, int id)
    {
      await  using var context = new InstagramCloneContext();
        bool doesExits = await DoesExitsAsync(id);
        if (doesExits == false)
            return null;
        user.Id = id;
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return user;
    }
    public async Task<User> GetByIdAsync(int id)
    {
       await using var context = new InstagramCloneContext();
        return await context.Users.Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Posts)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .SingleOrDefaultAsync(user => user.Id == id);

    }

    public async Task<bool> VerifyUser(LoginDto? userInfo)
    {
        if (userInfo == null) return false;
      await  using var context = new InstagramCloneContext();
      var dbUser = await  context.Users.FirstOrDefaultAsync(user => user.Username == userInfo.Username);
      if (dbUser == null) return false;
      return HashingManager.VerifyPassword(userInfo.Password,dbUser.Password);
    }

    public async Task<User> RegisterUser(RegisterDto registerInfo)
    {
        await using var context = new InstagramCloneContext();
        var user =await context.Users.FirstOrDefaultAsync(user => user.Username == registerInfo.Username);
        if (user != null) return null;
            
        var hashedPass = HashingManager.HashPassword(registerInfo.Password, HashingManager.GenerateSalt());
        var generatedUser = new User(registerInfo.Username, hashedPass);
        generatedUser.UserProfile.FullName = registerInfo.FullName;
        await context.Users.AddAsync(generatedUser);
        await context.SaveChangesAsync();
        return generatedUser;
    }
    public async Task<User>GetAsync(Expression<Func<User, bool>> filter)
    {
        await using var context = new InstagramCloneContext();
        return await context.Users.Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Posts)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Followers)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Following)
                                  .SingleOrDefaultAsync(filter);
    }
}