using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.Subscription;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public Task<ResponseAPI<List<GetAdministratorDto>>> GetAll();
		public Task<ResponseAPI<GetAdministratorDto>> Get(int id);
		public Task<ResponseAPI<GetAdministratorDto>> Register(RegisterAdministratorDto request);
		public Task<ResponseAPI<GetAdministratorDto>> Update(UpdateAdministratorDto request);
		public Task<ResponseAPI<GetAdministratorDto>> Delete(int id);
	}
}
