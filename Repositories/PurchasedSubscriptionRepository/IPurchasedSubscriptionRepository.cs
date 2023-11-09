using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.PurchasedSubscriptionRepository
{
	public interface IPurchasedSubscriptionRepository
	{
		public Task<PurchasedSubscription> Create(PurchasedSubscription request);
		public Task<List<PurchasedSubscription>> GetAllClientSub(int id);
	}
}
