namespace SportsComplexWebAPI.Models.Dto.Subscription
{
    public class UpdateSubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
