using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;

namespace SportsComplexWebAPI.Mapping
{
	public class PurchasedSubscriptionProfile : Profile
	{    
        public PurchasedSubscriptionProfile()
        {
            CreateMap<BuySubscriptionDto, PurchasedSubscription>();
            CreateMap<PurchasedSubscription, GetPurchasedSubscriptionDto>();
        }
    }
}
