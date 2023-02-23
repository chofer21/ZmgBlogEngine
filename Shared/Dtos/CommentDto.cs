namespace Shared.Dtos
{
	public class CommentDto
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; } = null!;

        public int UserId { get; set; }

        public int PostId { get; set; }

        public virtual UserDto? User { get; set; } = null!;
    }
}

