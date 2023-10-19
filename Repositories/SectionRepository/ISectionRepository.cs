using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.SectionRepository
{
    public interface ISectionRepository
    {
        public Task<Section?> GetByName(string name);
    }
}
