namespace Rabbit.Api.Models
{
    public class User
    {
        public int UserId { get; set; }

        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public ICollection<Post> Posts { get; set; }
    }
}
