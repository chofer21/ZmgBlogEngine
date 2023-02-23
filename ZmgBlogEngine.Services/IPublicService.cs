using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.Services
{
    public interface IPublicService
    {
        void AddComment(CommentDto commentDto);
        IEnumerable<PostDto> GetPublishedPosts();
    }
}