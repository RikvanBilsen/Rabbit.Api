namespace Rabbit.Api.DTOs
{
    public class PostDto
    {
        public required int PostId { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public required DateTime PublishDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastEdited { get; set; }
        public string? Tag { get; set; }
        public required UserDto User { get; set; }
    }
}