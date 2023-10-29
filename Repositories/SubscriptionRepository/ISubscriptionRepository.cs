using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Repositories.SubscriptionRepository
{
    public interface ISubscriptionRepository
    {
        public Task<List<Subscription>> GetAll();
        public Task<Subscription?> GetById(int id);
        public Task<Subscription> Create(Subscription subscription);
        public Task<Subscription?> Update(UpdateSubscriptionDto request);
        public Task<Subscription?> Delete(int id);
    }
}
