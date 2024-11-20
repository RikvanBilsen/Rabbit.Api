namespace Rabbit.Api.Models
{
    public class User
    {
        public int UserId { get; set; }

        public required string Username { get; set; }

        public required string PasswordHush { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public ICollection<Community> Communities { get; set;} = new List<Community>();
    }
}
