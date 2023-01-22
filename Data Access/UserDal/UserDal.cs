using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public class UserDal:EFentityRepository<User,InstagramCloneContext>,IEFentityRepository<User>,IUserDal
{
    
}