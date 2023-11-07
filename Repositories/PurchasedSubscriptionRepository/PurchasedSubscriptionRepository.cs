using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.PurchasedSubscriptionRepository
{
	public class PurchasedSubscriptionRepository : IPurchasedSubscriptionRepository
	{
		private readonly DataContext _context;

        public PurchasedSubscriptionRepository(DataContext context)
        {
			_context = context;
        }

        public async Task<PurchasedSubscription> Create(PurchasedSubscription request)
		{
			_context.PurchasedSubscriptions.Add(request);
			await _context.SaveChangesAsync();
			return request;
		}
	}
}
