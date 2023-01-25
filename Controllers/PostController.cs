using Instagram_Clone_Backend.Data_Access.PostDal;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    public class PostController : Controller
    {
        private IPostDal _PostDal;

        public PostController(IPostDal postDal)
        {
            _PostDal = postDal;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
