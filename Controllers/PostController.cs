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
        public async Task<IActionResult>GetPosts()
        {
            var posts = await  _PostDal.GetPostListAsync();
            return Ok(posts);
        }
        [HttpGet("GetUserPost")]
        public async Task<IActionResult> GetUserPosts([FromHeader]int id)
        {
            var userPosts = await _PostDal.GetPostListAsync(post => post.UserProfileId == id);
            return Ok(userPosts);
        }
        [HttpDelete("RemovePost")]
        public async Task<IActionResult> RemovePost([FromHeader]int id)
        {
            if (!await _iCommentDal.DoesExitsAsync(id))
                return NotFound();
            var deletedUser = await _PostDal.DeleteWithIdAsync(id);
            return Ok(deletedUser);
        }
        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromBody] PostDto post,int id)
        {
            if (!await _PostDal.DoesExitsAsync(id))
                return NotFound();
            var mappedPost = _mapper.Map<Post>(post);
            var updatedPost = await _PostDal.UpdateAsync(mappedPost,id);
            return Ok(updatedPost);

        }
        [HttpGet("GetUserComments")]
        public async Task<IActionResult> GetUserComments([FromHeader] int id)
        {

            var comments = await _iCommentDal.GetUserCommentAsync(id);
            return Ok(comments);
        }
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDto comment, [FromHeader]int postId ,[FromHeader]int userProfileId)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            if(!await _PostDal.DoesExitsAsync(postId))
                return NotFound();
            mappedComment.UserProfileId = userProfileId;
            mappedComment.PostId = postId;
            var addedComment = await _iCommentDal.Add(mappedComment);
            return Ok(addedComment);
        }
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteWithIdAsync([FromHeader]int commentId)
        {
            if(!await _iCommentDal.DoesExitsAsync(commentId))
                return NotFound();

            var comment = await _iCommentDal.DeleteWithIdAsync(commentId);
            return Ok(comment);
        }
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentDto comment, [FromHeader] int commentId, [FromHeader]int postId)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            mappedComment.Id = commentId;
            mappedComment.PostId = postId;
            var updatedComment = await _iCommentDal.UpdateAsync(mappedComment);
            return Ok(updatedComment);
        }
        [HttpPost("AddLike")]
        public async  Task<IActionResult> AddLike([FromHeader]int postId, [FromHeader]int UserProfileId)
        {
            if (!await _PostDal.DoesExitsAsync(postId))
                return NotFound();
            var like = await _LikeDal.AddAsync(postId,UserProfileId);
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
