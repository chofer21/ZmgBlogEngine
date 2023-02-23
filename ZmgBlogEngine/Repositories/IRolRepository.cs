using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
	public interface IRolRepository
	{
        IEnumerable<Rol> GetRoles();
        Rol? GetRolByID(int rolId);
        void InsertRol(Rol rol);
        void DeleteRol(int rolId);
        void UpdateRol(Rol rol);
        void Save();
	}
}