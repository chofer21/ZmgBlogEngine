using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using ZmgBlogEngine.Services;

namespace ZmgBlogEngine.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorController : ControllerBase
    {
        IEditorService _editorService;

        public EditorController(IEditorService editorService)
        {
            _editorService = editorService;
        }

        [HttpGet]
        [Route("posts")]
        public IEnumerable<PostDto> GetPendingPosts()
        {
            return _editorService.GetPendingPosts();
        }

        [HttpPut]
        [Route("approve")]
        public void ApprovePost(int postId)
        {
            _editorService.ApprovePost(postId);
        }

        [HttpPut]
        [Route("reject")]
        public void RejectPost(PostRejectedDto postDto)
        {
            postDto.EditorId = 2; // Todo session
            _editorService.RejectPost(postDto);
        }
    }

}

