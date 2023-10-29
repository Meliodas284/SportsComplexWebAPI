using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<CreateSubscriptionDto, Subscription>();
            CreateMap<Subscription, GetSubscriptionDto>();
        }
    }
}
