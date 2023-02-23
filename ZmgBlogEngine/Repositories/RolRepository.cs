using System;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
    /// <summary>
    /// Repository to manage db actions for Roles
    /// </summary>
	public class RolRepository : IRolRepository
	{
        private ZmgDbContext _context;

        public RolRepository(ZmgDbContext context)
		{
            _context = context;
        }

        public IEnumerable<Rol> GetRoles()
        {
            return _context.Rols.ToList();
        }

        public Rol? GetRolByID(int rolId)
        {
            return _context.Rols.Find(rolId);
        }

        public void InsertRol(Rol rol)
        {
            _context.Rols.Add(rol);
        }

        public void DeleteRol(int rolId)
        {
            var item = _context.Rols.Find(rolId);
            if (item != null)
            {
                _context.Rols.Remove(item);
            }
        }

        public void UpdateRol(Rol rol)
        {
            var item = _context.Rols.Find(rol.Id);
            if (item != null)
            {
                item.Name = rol.Name;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

