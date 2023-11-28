using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.SectionRepository
{
    public interface ISectionRepository
    {
        public Task<List<Section>> GetAll();
        public Task<Section?> GetById(int id);
        public Task<Section> Create(Section request);
        public Task<Section?> Delete(int id);
        public Task<Section?> GetByName(string name);
    }
}
