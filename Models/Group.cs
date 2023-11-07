using System.Text.Json.Serialization;

namespace SportsComplexWebAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Coach Coach { get; set; }
        public int CoachId { get; set; }
        public List<PurchasedSubscription> PurchasedSubscriptions { get; set; }
    }
}
