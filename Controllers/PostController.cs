using Instagram_Clone_Backend.Data_Access.PostDal;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [Route("api/{controller}")]
    public class PostController : Controller
    {
        private IPostDal _PostDal;
        public PostController(IPostDal postDal)
        {
            _PostDal = postDal;
        }
        [HttpPost("/AddPost")]
        public IActionResult AddPost([FromBody] Post post)
        {
            _PostDal.Add(post);
            return Ok(post);
        }
    }
}
