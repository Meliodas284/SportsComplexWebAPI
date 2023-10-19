using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public Task<ResponseAPI<GetAdministratorDto>> RegisterAdmin(RegisterAdministratorDto request);
        public Task<ResponseAPI<GetCoachDto>> RegisterCoach(RegisterCoachDto request);
    }
}
