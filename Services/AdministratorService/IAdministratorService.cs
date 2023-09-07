using SportsComplexWebAPI.Dtos.Administrator;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public interface IAdministratorService
    {
        public Task<ServiceResponse<List<GetAdminDto>>> GetAdministrators();
        public Task<ServiceResponse<GetAdminDto>> GetSingleAdmin(int id);
        public Task<ServiceResponse<GetAdminDto>> RegisterAdmin(RegisterAdminDto request);
        public Task<ServiceResponse<GetAdminDto>> PutAdministrator(PutAdminDto request);
        public Task<ServiceResponse<GetAdminDto>> DeleteAdmin(int id);
    }
}
