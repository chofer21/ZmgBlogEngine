using System;
using System.Collections.Generic;

namespace ZmgBlogEngine.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RolId { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual Rol Rol { get; set; } = null!;
}
