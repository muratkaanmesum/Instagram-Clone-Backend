using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("[controller]")]
        public IActionResult Index()
        {
            return Ok("test123");
        }
    }
}
