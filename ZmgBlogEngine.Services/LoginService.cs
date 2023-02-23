using System;
using AutoMapper;
using Shared;
using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;
using ZmgBlogEngine.DataAccess.Repositories;

namespace ZmgBlogEngine.Services
{
	public class PublicService : IPublicService
	{
		IPostRepository _postRepository;
		ICommentRepository _commentRepository;
		IMapper _mapper;

		public PublicService(IPostRepository postRepository, ICommentRepository commentRepository,
			IMapper mapper)
		{
			_postRepository = postRepository;
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public IEnumerable<PostDto> GetPublishedPosts()
		{
			var posts = _postRepository.GetPostsByStatus(Status.Published);

			return _mapper.Map<List<PostDto>>(posts);
		}

		public void AddComment(CommentDto commentDto)
		{
			if (IsPostValidForComment(commentDto.PostId))
			{
				var newComment = new Comment
				{
					Content = commentDto.Content,
					Date = DateTime.Now,
					UserId = commentDto.UserId,
					PostId = commentDto.PostId
				};

				_commentRepository.InsertComment(newComment);
				_commentRepository.Save();
			}
		}

		private bool IsPostValidForComment(int postId)
		{
			var post = _postRepository.GetPostByID(postId);

			if (post != null && post.Status == Status.Published.ToString())
			{
				return true;
			}

			return false;
		}
	}
}

