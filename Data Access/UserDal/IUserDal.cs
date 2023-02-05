using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public interface IUserDal:IEFentityRepository<User>
{
    public Task<List<User>> GetAllData();
    public Task<User>? DeleteByIdAsync(int id);
    public Task<User> Update(User user, int id);
}