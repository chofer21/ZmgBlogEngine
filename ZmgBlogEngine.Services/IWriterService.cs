using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.Services
{
    public interface IWriterService
    {
        void AddPost(PostDto postDto);
        void EditPost(PostDto postDto);
        IEnumerable<PostDto> GetWriterPosts(int authorId);
        IEnumerable<PostDto> GetWriterPostsToUpdate(int authorId);
        void SubmitPost(int postId);
    }
}