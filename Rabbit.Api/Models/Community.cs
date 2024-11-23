namespace Rabbit.Api.Models
{
    public class Community
    {
        public int CommunityId { get; set; }

        public required string CommunityName { get; set; }
        public required string CommunityDescription { get; set; }
    }
}
