using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;

namespace SportsComplexWebAPI.Repositories.AdministratorRepository
{
    public interface IAdministratorRepository
    {
        public Task<List<Administrator>> GetAll();
        public Task<Administrator?> GetById(int id);
        public Task<Administrator> Create(Administrator administrator);
        public Task<Administrator?> Update(UpdateAdministratorDto request);
        public Task<Administrator?> Delete(int id);
    }
}
