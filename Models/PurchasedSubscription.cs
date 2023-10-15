namespace SportsComplexWebAPI.Models
{
    public class PurchasedSubscription
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
    }
}
