namespace Rabbit.Api.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
