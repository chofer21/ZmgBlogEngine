using System;
using Shared;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    /// <summary>
    /// Repository to manage db actions for Comments
    /// </summary>
	public class CommentRepository : ICommentRepository
    {
        private ZmgDbContext _context;

        public CommentRepository(ZmgDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.ToList();
        }

        public Comment? GetCommentByID(int commentId)
        {
            return _context.Comments.Find(commentId);
        }

        public void InsertComment(Comment comment)
        {
            var post = _context.Posts.Find(comment.PostId);

            if (post != null && post.Status == Status.Published.ToString())
            {
                _context.Comments.Add(comment);
            }
            else
            {
                throw new Exception("Post not valid for new comment");
            }
        }

        public void DeleteComment(int commentId)
        {
            var item = _context.Comments.Find(commentId);
            if (item != null)
            {
                _context.Comments.Remove(item);
            }
        }

        public void UpdateComment(Comment comment)
        {
            var item = _context.Comments.Find(comment.Id);
            if (item != null)
            {
                item.Content = comment.Content;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
