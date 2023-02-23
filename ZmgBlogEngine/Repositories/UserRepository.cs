using System;
using Microsoft.EntityFrameworkCore;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.DataAccess.Repositories
{
	/// <summary>
	/// Repository to manage db actions for Users
	/// </summary>
	public class UserRepository : IUserRepository
	{
		private ZmgDbContext _context;

		public UserRepository(ZmgDbContext context)
		{
			_context = context;
		}

		public IEnumerable<User> GetUsers()
		{
			return _context.Users.ToList();
		}

		public User? GetUserByID(int userId)
		{
			return _context.Users.Find(userId);
		}

		public User? GetUserByIdAndPassword(int userId, string password)
		{
			return _context.Users
					.Include(x => x.Rol)
					.FirstOrDefault(x => x.Id == userId && x.Password == password);
		}

		public void InsertUser(User user)
		{
			_context.Users.Add(user);
		}

		public void DeleteUser(int userId)
		{
			var item = _context.Users.Find(userId);
			if (item != null)
			{
				_context.Users.Remove(item);
			}
		}

		public void UpdateUser(User user)
		{
			var item = _context.Users.Find(user.Id);
			if (item != null)
			{
				item.Name = user.Name;
				item.RolId = user.RolId;
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}

