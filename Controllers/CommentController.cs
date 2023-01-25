using Instagram_Clone_Backend.Data_Access.CommentDal;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Clone_Backend.Controllers
{
    [Route("api/[Controller]")]
    public class CommentController : Controller
    {
        private ICommentDal _iCommentDal;
        public CommentController(ICommentDal commentDal)
        {
            _iCommentDal = commentDal;
        }
        [HttpGet("/GetUserComments")]
        public IActionResult GetUserComments([FromHeader]int id)
        {

            var comments = _iCommentDal.GetUserComment(id);
            return Ok(comments);
        }
        [HttpPost("/AddComment")]
        public IActionResult Add([FromBody] Comment comment)
        {
            var addedComment   = _iCommentDal.Add(comment);
            return Ok(addedComment);
        }

    }
}
