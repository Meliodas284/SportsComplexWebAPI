using SportsComplexWebAPI.Models.Dto.GroupDto;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto
{
	public class GetPurchasedSubscriptionDto
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public GetSubscriptionDto OunSubscription { get; set; } = new();
		public GetGroupDto OunGroup { get; set; } = new();
	}
}
