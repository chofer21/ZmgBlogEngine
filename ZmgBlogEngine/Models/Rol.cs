using System;
using System.Collections.Generic;

namespace ZmgBlogEngine.DataAccess.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
