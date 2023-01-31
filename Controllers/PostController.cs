using Instagram_Clone_Backend.Data_Access.CommentDal;
using Instagram_Clone_Backend.Data_Access.PostDal;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private IPostDal _PostDal;
        private ICommentDal _iCommentDal;
        public PostController(IPostDal postDal, ICommentDal iCommentDal)
        {
            _PostDal = postDal;
            _iCommentDal = iCommentDal;
        }
        [HttpPost("AddPost")]
        public IActionResult AddPost([FromBody] Post post)
        {
            _PostDal.Add(post);
            return Ok(post);
        }
        [HttpGet("GetUserComments")]
        public IActionResult GetUserComments([FromHeader] int id)
        {

            var comments = _iCommentDal.GetUserComment(id);
            return Ok(comments);
        }
        [HttpPost("AddComment")]
        public IActionResult Add([FromBody] Comment comment)
        {
            var addedComment = _iCommentDal.Add(comment);
            return Ok(addedComment);
        }

    }
}
