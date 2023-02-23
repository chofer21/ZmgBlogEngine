using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();
        Comment? GetCommentByID(int commentId);
        void InsertComment(Comment comment);
        void DeleteComment(int commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}