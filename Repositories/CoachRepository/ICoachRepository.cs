using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.CoachRepository
{
    public interface ICoachRepository
    {
        public Task<List<Coach>> GetAll();
        public Task<Coach?> GetById(int id);
        public Task<Coach> Create(Coach coach);
        public Task<Coach?> Update(UpdateCoachDto request);
        public Task<Coach?> Delete(int id);
    }
}
