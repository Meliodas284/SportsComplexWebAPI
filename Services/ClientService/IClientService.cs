using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;

namespace SportsComplexWebAPI.Services.ClientService
{
    public interface IClientService
    {
        public Task<ResponseAPI<GetClientDto>> Register(RegisterClientDto request);
        public Task<ResponseAPI<GetPurchasedSubscriptionDto>> BuySubscription(BuySubscriptionDto request);
        public Task<ResponseAPI<List<GetPurchasedSubscriptionDto>>> GetAllSubscriptons();
    }
}
