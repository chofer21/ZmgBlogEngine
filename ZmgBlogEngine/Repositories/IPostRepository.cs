using Shared;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPostsByAuthor(int authorId);
        IEnumerable<Post> GetPostsByStatus(Status status);
        IEnumerable<Post> GetPostsByAuthorAndStatus(int authorId, Status status);
        IEnumerable<Post> GetPostsByAuthorAndToUpdate(int authorId);
        Post? GetPostByID(int postId);
        void InsertPost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void UpdatePostStatus(int postId, Status status);
        void Save();
    }
}