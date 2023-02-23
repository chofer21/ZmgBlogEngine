namespace Shared.Dtos
{
	public class PostRejectedDto
    {
        public int Id { get; set; }

        public string? RejectedReason { get; set; }

        public int? EditorId { get; set; }
    }
}

