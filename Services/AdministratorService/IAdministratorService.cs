using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public Task<ResponseAPI<GetAdministratorDto>> RegisterAdmin(RegisterAdministratorDto request);
        public Task<ResponseAPI<GetCoachDto>> RegisterCoach(RegisterCoachDto request);
        public Task<ResponseAPI<GetSubscriptionDto>> CreateSubscription(CreateSubscriptionDto request);
        public Task<ResponseAPI<List<GetSubscriptionDto>>> GetAllSubscriptions();
    }
}
