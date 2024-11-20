using System.ComponentModel;

namespace Rabbit.Api.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public required string Title { get; set; }

        public required string Body { get; set; }

        [DisplayName("Published at:")]
        public DateTime? PublishDate { get; set; } = DateTime.UtcNow;

        [DisplayName("Last Edited at:")]
        public DateTime LastEdited { get; set; }

        public string? Tag { get; set; }

        //foreignkey & navigation property
        public int UserId { get; set; }
        public required User User { get; set; }

        public int CommunityId { get; set; }
        public Community? Community { get; set; } = null;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
