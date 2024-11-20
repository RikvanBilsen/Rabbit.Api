namespace Rabbit.Api.Models
{
    public class Vote
    {
        public int Id { get; set; } 
        public int Value { get; set; } 

        public int UserId { get; set; }
        public required User User { get; set; }

        public int? PostId { get; set; } 
        public Post? Post { get; set; }

        public int? CommentId { get; set; } 
        public Comment? Comment { get; set; }
    }
}