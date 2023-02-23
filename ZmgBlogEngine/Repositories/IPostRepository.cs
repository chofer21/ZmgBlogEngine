using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        Post? GetPostByID(int postId);
        void InsertPost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}