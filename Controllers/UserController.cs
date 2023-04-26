using AutoMapper;
using Instagram_Clone_Backend.Data_Access.FollowerDal;
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
        private IFollowerDal _followerDal;
        public UserController(IUserDal userDal, IMapper mapper, IFollowerDal followerDal)
        {
            _userDal = userDal ?? throw new NullReferenceException();
            _mapper = mapper ?? throw new NullReferenceException();
            _followerDal = followerDal ?? throw new NullReferenceException();
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var mappedProfile = _mapper.Map<UserProfile>(user);
            mappedUser.UserProfile = mappedProfile;
            var newUser = _userDal.Add(mappedUser);



            return Ok(mappedUser);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllData()
        {
            var list = await _userDal.GetAllData();
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromHeader] int id)
        {
            var deletedUser = await _userDal.DeleteByIdAsync(id);
            return deletedUser == null ? NotFound() : Ok(deletedUser);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserDto user, [FromHeader] int id)
        {
            var mappedUser = _mapper.Map<User>(user);
            var mappedUserProfile = _mapper.Map<UserProfile>(user);
            mappedUser.UserProfile = mappedUserProfile;
            var updatedUser = await _userDal.Update(mappedUser, id);
            return updatedUser == null ? NotFound("Id Doesn't Exits in the database") : Ok(updatedUser);
        }

        [HttpPost("AddFollower")]
        public async Task<IActionResult> AddFollower([FromBody] FollowerDto follower)
        {
            var mappedFollower = _mapper.Map<Follower>(follower);
            var returnedFollower = await _followerDal.AddFollower(mappedFollower);
            if (returnedFollower == null)
                return BadRequest("User is already followed");
            return Ok(returnedFollower);
        }

        [HttpGet("GetUserFollowers")]
        public async Task<IActionResult> GetUserFollowers([FromHeader]int id)
        {

            var followers = await _followerDal.GetUserFollowers(id);
            return Ok(followers);
        }
        [HttpGet("GetUserFollowing")]
        public async Task<IActionResult> GetUserFollowing([FromHeader]int id)
        {
            var following = await _followerDal.GetUserFollowing(id);
            return Ok(following);
        }
        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginDto userInfo)
        {
            var loginAttempt = await _userDal.VerifyUser(userInfo);
            if(!loginAttempt)
                return Unauthorized("Wrong username or password!");
            else
            {
                var user =await  _userDal.GetAsync(user => user.Username == userInfo.Username);
                return Ok(user);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody]RegisterDto userInfo)
        {
            var user =await _userDal.RegisterUser(userInfo);
            if (user == null)
                return BadRequest("Username already in use!");
            return Ok(user);
        }
        [HttpGet("getByUsername")]
        public async Task<IActionResult> GetUserbyUsername([FromHeader]string username)
        {
            var user = await _userDal.GetAsync(user => user.Username == username);
            return Ok(user);
        }
        [HttpGet("getAllFollowers")]
        public IActionResult GetAllFollowers()
        {
            return Ok(_followerDal.GetList(null));
        }
    }
}
