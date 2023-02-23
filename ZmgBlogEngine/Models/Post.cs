using System;
using System.Collections.Generic;

namespace ZmgBlogEngine.DataAccess.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Content { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual User User { get; set; } = null!;
}
