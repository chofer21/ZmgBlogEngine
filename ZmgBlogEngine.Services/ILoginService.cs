using Shared.Dtos;

namespace ZmgBlogEngine.Services
{
    public interface ILoginService
    {
        UserDto GetUserByIdAndPassword(int userId, string password);
    }
}