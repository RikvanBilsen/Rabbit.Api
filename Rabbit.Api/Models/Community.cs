using System.ComponentModel;

namespace Rabbit.Api.Models
{
    public class Community //nog niet aan database toegevoegd FK restraint???
    {
        public int CommunityId { get; set; }

        [DisplayName("Community")]
        public required string CommunityName { get; set; }

        public required string CommunityDescription { get; set; }

        public int CreatorId { get; set; }
        public required User Creator { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
