using AutoMapper;
using Shared;
using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;
using ZmgBlogEngine.DataAccess.Repositories;

namespace ZmgBlogEngine.Services
{
	public class WriterService : IWriterService
	{
		IPostRepository _postRepository;
		IMapper _mapper;

		public WriterService(IPostRepository postRepository, IMapper mapper)
		{
			_postRepository = postRepository;
			_mapper = mapper;
		}

		// TODO session author
		public IEnumerable<PostDto> GetWriterPosts(int authorId)
		{
			var posts = _postRepository.GetPostsByAuthor(authorId);

			return _mapper.Map<List<PostDto>>(posts);
		}

		// TODO session author
		public IEnumerable<PostDto> GetWriterPostsToUpdate(int authorId)
		{
			var posts = _postRepository.GetPostsByAuthorAndToUpdate(authorId);
			return _mapper.Map<List<PostDto>>(posts);
		}

		// TODO session author
		public void AddPost(PostDto postDto)
		{
			var newPost = new Post
			{
				Title = postDto.Title,
				Date = DateTime.Now,
				Content = postDto.Content,
				Status = Status.New.ToString(),
				UserId = postDto.UserId
			};

			_postRepository.InsertPost(newPost);
			_postRepository.Save();
		}

		// TODO session author
		public void EditPost(PostDto postDto)
		{
			if (postDto.Id != null && IsPostValidForEdit(postDto.Id.Value))
			{
				var postToEdit = new Post
				{
					Id = postDto.Id.Value,
					Title = postDto.Title,
					Date = DateTime.Now,
					Content = postDto.Content,
					Status = Status.New.ToString(),
					UserId = postDto.UserId
				};

				_postRepository.UpdatePost(postToEdit);
				_postRepository.Save();
			}
		}

		// TODO session author
		public void SubmitPost(int postId)
		{
			if (IsPostValidForEdit(postId))
			{
				_postRepository.UpdatePostStatus(postId, Status.PendingApproval);
				_postRepository.Save();
			}
		}

		private bool IsPostValidForEdit(int postId)
		{
			var post = _postRepository.GetPostByID(postId);

			if (post != null && post.Status != Status.Published.ToString())
			{
				return true;
			}

			return false;
		}
	}
}
