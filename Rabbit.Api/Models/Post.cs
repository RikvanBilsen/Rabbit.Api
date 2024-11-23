namespace Rabbit.Api.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public required string Title { get; set; }
        public required string Body { get; set; }

        public DateTime? PublishDate { get; set; } = DateTime.UtcNow;
        public DateTime LastEdited { get; set; }

        public string? Tag { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
