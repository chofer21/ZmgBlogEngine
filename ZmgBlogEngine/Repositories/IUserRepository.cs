using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
	public interface IUserRepository
	{
        IEnumerable<User> GetUsers();
        User? GetUserByID(int userId);
        User? GetUserByIdAndPassword(int userId, string password);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void Save();
	}
}