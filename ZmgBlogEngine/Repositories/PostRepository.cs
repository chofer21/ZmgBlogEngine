using System;
using Microsoft.EntityFrameworkCore;
using Shared;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    /// <summary>
    /// Repository to manage db actions for Posts
    /// </summary>
	public class PostRepository : IPostRepository
    {
        private ZmgDbContext _context;

        public PostRepository(ZmgDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public IEnumerable<Post> GetPostsByAuthor(int authorId)
        {
            return _context
                    .Posts
                    .Where(x => x.UserId == authorId)
                    .ToList();
        }

        public IEnumerable<Post> GetPostsByStatus(Status status)
        {
            return _context
                    .Posts
                    .Where(x => x.Status == status.ToString())
                    .Include(x => x.User)
                    .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                    .ToList();
        }

        public IEnumerable<Post> GetPostsByAuthorAndStatus(int authorId, Status status)
        {
            return _context
                    .Posts
                    .Where(x => x.UserId == authorId && x.Status == status.ToString())
                    .ToList();
        }

        public IEnumerable<Post> GetPostsByAuthorAndToUpdate(int authorId)
        {
            return _context
                    .Posts
                    .Where(x => x.UserId == authorId &&
                                x.Status != Status.Published.ToString() &&
                                x.Status != Status.PendingApproval.ToString())
                    .ToList();
        }

        public Post? GetPostByID(int postId)
        {
            return _context.Posts.Find(postId);
        }

        public void InsertPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(int postId)
        {
            var item = _context.Posts.Find(postId);
            if (item != null)
            {
                _context.Posts.Remove(item);
            }
        }

        public void UpdatePost(Post post)
        {
            var item = _context.Posts.Find(post.Id);
            if (item != null)
            {
                item.Title = post.Title;
                item.Content = post.Content;
                item.Status = post.Status;
                item.EditorId = post.EditorId;
                item.RejectedReason = post.RejectedReason;
            }
        }

        public void UpdatePostStatus(int postId, Status status)
        {
            var item = _context.Posts.Find(postId);
            if (item != null)
            {
                item.Status = status.ToString();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

