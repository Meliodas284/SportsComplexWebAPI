using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.SectionRepository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DataContext _context;

        public SectionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Section?> GetByName(string name)
        {
            return await _context.Sections.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
