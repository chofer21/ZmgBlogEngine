using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.Services
{
	public interface IEditorService
	{
		void ApprovePost(int postId);
		IEnumerable<PostDto> GetPendingPosts();
		void RejectPost(PostRejectedDto postDto);
	}
}