using Microsoft.EntityFrameworkCore;
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

		public async Task<List<PurchasedSubscription>> GetAllClientSub(int id)
		{
			return await _context.PurchasedSubscriptions
				.Include(p => p.Client)
				.Include(p => p.Group)
				.Include(p => p.Group.Coach)
				.Include(p => p.Subscription)
				.Where(p => p.ClientId == id).ToListAsync();
		}
	}
}
