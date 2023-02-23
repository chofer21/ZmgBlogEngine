namespace Shared.Dtos
{
	public class PostDto
    {
        public int? Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Content { get; set; } = null!;

        public string? Status { get; set; } = null!;

        public int UserId { get; set; }

        public string? RejectedReason { get; set; }

        public int? EditorId { get; set; }
        public virtual ICollection<CommentDto> Comments { get; } = new List<CommentDto>();
        public virtual UserDto? Editor { get; set; }

        public virtual UserDto? User { get; set; } = null!;
    }
}

