using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Repositories.SubscriptionRepository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DataContext _context;

        public SubscriptionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Subscription> Create(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<Subscription?> Delete(int id)
        {
            var subscription = await GetById(id);
            if (subscription == null)
                return null;
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<List<Subscription>> GetAll()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription?> GetById(int id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subscription?> Update(UpdateSubscriptionDto request)
        {
            var subscription = await GetById(request.Id);
            if (subscription == null)
                return null;
            subscription.Name = request.Name;
            subscription.Duration = request.Duration;
            subscription.Price = request.Price;
            subscription.Description = request.Description;
            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}
