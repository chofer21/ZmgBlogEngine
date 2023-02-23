using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using ZmgBlogEngine.Services;

namespace ZmgBlogEngine.Endpoints.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PublicController : ControllerBase
	{
		IPublicService _publicService;

		public PublicController(IPublicService publicService)
		{
			_publicService = publicService;
		}

		[HttpGet]
		[Route("posts")]
		public IEnumerable<PostDto> GetPosts()
		{
			return _publicService.GetPublishedPosts();
		}

		[HttpPost]
		[Route("comment")]
		public void PostComment(CommentDto commentDto)
		{
			_publicService.AddComment(commentDto);
		}

	}
}
