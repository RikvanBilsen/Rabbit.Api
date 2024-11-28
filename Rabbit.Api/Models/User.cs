namespace Rabbit.Api.Models
{
    public class User
    {
        public int UserId { get; set; }

        public required string UserName { get; set; }
        public required string PasswordHush { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public ICollection<Post> Posts { get; set; }
    }
}
