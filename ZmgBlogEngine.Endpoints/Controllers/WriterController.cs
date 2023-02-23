using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using ZmgBlogEngine.Services;

namespace ZmgBlogEngine.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Writer")]
    public class WriterController : ControllerBase
    {
        IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        [Route("posts")]
        public IEnumerable<PostDto> GetWriterPosts(int writerId)
        {
            return _writerService.GetWriterPosts(writerId);
        }

        [HttpGet]
        [Route("postsToUpdate")]
        public IEnumerable<PostDto> GetWriterPostsToUpdate(int writerId)
        {
            return _writerService.GetWriterPostsToUpdate(writerId);
        }

        [HttpPost]
        [Route("post")]
        public void AddPost(PostDto postDto)
        {
            _writerService.AddPost(postDto);
        }

        [HttpPut]
        [Route("post")]
        public void UpdatePost(PostDto postDto)
        {
            _writerService.EditPost(postDto);
        }

        [HttpPut]
        [Route("post/submit")]
        public void SubmitPost(int postId)
        {
            _writerService.SubmitPost(postId);
        }

    }
}
