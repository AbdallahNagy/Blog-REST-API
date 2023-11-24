using Blog.BL.Managers.Posts;
using Blog.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/v1/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _postManager;
        public PostController(IPostManager postManager) 
        {
            _postManager = postManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            return _postManager.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Post?> Get(int id)
        {
            return _postManager.GetById(id);
        }

        [HttpPost]
        public ActionResult<Post> Post(Post post)
        {
            return _postManager.Add(post);
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Post> Patch(Post post)
        {
            return _postManager.Update(post);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _postManager.Delete(id);
            return Ok();
        }
    }
}
