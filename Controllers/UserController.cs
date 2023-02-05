using AutoMapper;
using Instagram_Clone_Backend.Data_Access.UserDal;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class UserController : ControllerBase
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        public UserController(IUserDal userDal , IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper ?? throw new NullReferenceException();
        }
        [HttpPost("/Add")]
        public IActionResult Add([FromBody]UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var mappedProfile = _mapper.Map<UserProfile>(user);
            mappedUser.UserProfile = mappedProfile;
            var newUser = _userDal.Add(mappedUser);



            return Ok(mappedUser);
        }
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllData()
        {
            var list = await _userDal.GetAllData();
            return Ok(list);
        }

        [HttpDelete("/Delete")]
        public async Task<IActionResult> Delete([FromHeader]int id)
        {
            var deletedUser = await _userDal.DeleteByIdAsync(id);
            return deletedUser == null ? NotFound() :Ok(deletedUser);
        }
        [HttpPut("/Update")]
        public async Task<IActionResult> Update([FromBody] UserDto user, [FromHeader]int id)
        {
            var mappedUser = _mapper.Map<User>(user);
            var mappedUserProfile = _mapper.Map<UserProfile>(user);
            mappedUser.UserProfile = mappedUserProfile;
            var updatedUser = await _userDal.Update(mappedUser,id);
            return updatedUser == null ? NotFound("Id Doesnt Exits in the database"): Ok(updatedUser);
        }
    }
}
