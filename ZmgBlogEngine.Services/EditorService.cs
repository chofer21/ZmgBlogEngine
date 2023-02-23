using AutoMapper;
using Shared;
using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;
using ZmgBlogEngine.DataAccess.Repositories;

namespace ZmgBlogEngine.Services
{
	public class EditorService : IEditorService
	{
		IPostRepository _postRepository;
		IMapper _mapper;

		public EditorService(IPostRepository postRepository, IMapper mapper)
		{
			_postRepository = postRepository;
			_mapper = mapper;
		}

		public IEnumerable<PostDto> GetPendingPosts()
		{
			var posts = _postRepository.GetPostsByStatus(Status.PendingApproval);

			return _mapper.Map<List<PostDto>>(posts);
		}

		public void ApprovePost(int postId)
		{
			var post = _postRepository.GetPostByID(postId);

			if (IsPostValidForReview(post!))
			{
				_postRepository.UpdatePostStatus(postId, Status.Published);
				_postRepository.Save();
			}
		}

		public void RejectPost(PostRejectedDto postDto)
		{
			var post = _postRepository.GetPostByID(postDto.Id);

			if (IsPostValidForReview(post!))
			{
				var postToEdit = new Post
				{
					Id = post.Id,
					Title = post.Title,
					Date = post.Date,
					Content = post.Content,
					UserId = post.UserId,

					// Updated values
					EditorId = postDto.EditorId,
					Status = Status.Rejected.ToString(),
					RejectedReason = postDto.RejectedReason
				};

				_postRepository.UpdatePost(postToEdit);
				_postRepository.Save();
			}
			
		}

		private bool IsPostValidForReview(Post post)
		{
			if (post != null && post.Status == Status.PendingApproval.ToString())
			{
				return true;
			}

			return false;
		}
	}
}

