namespace SportsComplexWebAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Description { get; set; }
        public List<PurchasedSubscription> PurchasedSubscriptions { get; set; }
    }
}
