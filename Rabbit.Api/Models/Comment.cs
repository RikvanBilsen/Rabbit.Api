using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization.Metadata;

namespace Rabbit.Api.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PostId { get; set; }
        public required Post Post { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
