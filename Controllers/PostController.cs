using AutoMapper;
using Instagram_Clone_Backend.Data_Access.CommentDal;
using Instagram_Clone_Backend.Data_Access.LikeDal;
using Instagram_Clone_Backend.Data_Access.PostDal;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostDal _PostDal;
        private readonly ICommentDal _iCommentDal;
        private readonly ILikeDal _LikeDal;
        private readonly IMapper _mapper;
        public PostController(IMapper mapper ,IPostDal postDal, ICommentDal iCommentDal,ILikeDal likeDal)
        {
            _mapper = mapper;
            _PostDal = postDal;
            _iCommentDal = iCommentDal;
            _LikeDal = likeDal;

        }
        [HttpPost("AddPost")]
        public IActionResult AddPost([FromBody] PostDto post)
        {
            var mappedPost = _mapper.Map<Post>(post);
            _PostDal.Add(mappedPost);
            return Ok(post);
        }
        [HttpGet("GetPosts")]
        public IActionResult GetPosts()
        {
            var posts = _PostDal.GetList();
            return Ok(posts);
        }
        [HttpGet("GetUserPost")]
        public IActionResult GetUserPosts([FromHeader]int id)
        {
            var userPosts = _PostDal.GetPostList(post => post.UserProfileId == id);
            return Ok(userPosts);
        }
        [HttpDelete("RemovePost")]
        public IActionResult RemovePost([FromBody]Post post)
        {
            _PostDal.Delete(post);
            return Ok(post);
        }
        [HttpPut("UpdatePost")]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            var updatedPost = _PostDal.Update(post);
            return Ok(post);
        }
        [HttpGet("GetUserComments")]
        public async Task<IActionResult> GetUserComments([FromHeader] int id)
        {

            var comments = await _iCommentDal.GetUserCommentAsync(id);
            return Ok(comments);
        }
        [HttpPost("AddComment")]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            var addedComment = _iCommentDal.Add(comment);
            return Ok(addedComment);
        }
        [HttpDelete("DeleteComment")]
        public IActionResult DeleteComment([FromBody]Comment comment)
        {
            _iCommentDal.Delete(comment);
            return Ok(comment);
        }
        [HttpPut("UpdateComment")]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            var updatedComment = _iCommentDal.Update(comment);
            return Ok(updatedComment);
        }
        [HttpPost("AddLike")]
        public IActionResult AddLike([FromBody] Like like)
        {
            _LikeDal.Add(like);
            return Ok(like);
        }
        [HttpDelete("DeleteLike")]
        public IActionResult DeleteLike([FromBody] Like like)
        {
            _LikeDal.Delete(like);
            return Ok(like);
        }
    }
}
