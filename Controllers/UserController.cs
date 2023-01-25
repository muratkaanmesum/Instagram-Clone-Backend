using Instagram_Clone_Backend.Data_Access.UserDal;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [Route("/api/[Controller]")]
    public class UserController : Controller
    {
        private IUserDal _userDal;
        public UserController(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [HttpPost("/Add")]
        public IActionResult Add([FromBody]User user)
        {
            var newUser = _userDal.Add(user);
            return Ok(newUser);
        }
        [HttpGet("/GetAll")]
        public IActionResult GetAllUsers()
        {
            var list = _userDal.GetAllData();
            return Ok(list);
        }

        [HttpDelete("/Delete")]
        public IActionResult Delete([FromBody]User user)
        {
            var deletedUser = _userDal.Delete(user);
            return deletedUser != null ? Ok(deletedUser) : BadRequest();
        }
        [HttpPut("/Update")]
        public IActionResult Update([FromBody] User user)
        {
            var updatedUser = _userDal.Update(user);
            return Ok(updatedUser);
        }
    }
}
