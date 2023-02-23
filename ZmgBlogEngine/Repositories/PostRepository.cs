using System;
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
                item.Status = item.Status;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

