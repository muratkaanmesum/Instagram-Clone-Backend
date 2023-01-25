using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public interface IUserDal:IEFentityRepository<User>
{
    public List<User> GetAllData();
}