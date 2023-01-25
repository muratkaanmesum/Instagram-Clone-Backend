using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Data_Access.PostDal;

public class PostDal:EFentityRepository<Post,InstagramCloneContext>,IPostDal
{

}