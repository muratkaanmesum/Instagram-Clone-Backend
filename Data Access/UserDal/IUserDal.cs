using System.Linq.Expressions;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public interface IUserDal : IEFentityRepository<User>
{
    public Task<List<User>> GetAllData();
    public Task<User>? DeleteByIdAsync(int id);
    public Task<User> Update(User user, int id);
    public Task<User> GetByIdAsync(int id);
    public Task<bool> VerifyUser(LoginDto userInfo);
    public Task<User> RegisterUser(RegisterDto registerInfo);
    public Task<User> GetAsync(Expression<Func<User, bool>> filter);
}