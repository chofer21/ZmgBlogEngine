using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using ZmgBlogEngine.Services;

namespace ZmgBlogEngine.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {
        IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        [Route("posts")]
        public IEnumerable<PostDto> GetWriterPosts()
        {
            var authorId = 1; // Todo hacer esto por session
            return _writerService.GetWriterPosts(authorId);
        }

        [HttpGet]
        [Route("postsToUpdate")]
        public IEnumerable<PostDto> GetWriterPostsToUpdate()
        {
            var authorId = 1; // Todo hacer esto por session
            return _writerService.GetWriterPostsToUpdate(authorId);
        }

        [HttpPost]
        [Route("post")]
        public void AddPost(PostDto postDto)
        {
            postDto.UserId = 1; // TOdo add this with session
            _writerService.AddPost(postDto);
        }

        [HttpPut]
        [Route("post")]
        public void UpdatePost(PostDto postDto)
        {
            postDto.UserId = 1; // TOdo add this with session
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
