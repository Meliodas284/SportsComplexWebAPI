using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace SportsComplexWebAPI.Repositories.SectionRepository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DataContext _context;

        public SectionRepository(DataContext context)
        {
            _context = context;
        }

		public async Task<Section> Create(Section request)
		{
			_context.Sections.Add(request);
			await _context.SaveChangesAsync();
			return request;
		}

		public async Task<Section?> Delete(int id)
		{
			var section = await GetById(id);
			if (section == null)
				return null;
			_context.Sections.Remove(section);
			await _context.SaveChangesAsync();
			return section;
		}

		public async Task<List<Section>> GetAll()
		{
			return await _context.Sections.ToListAsync();
		}

		public async Task<Section?> GetById(int id)
		{
			return await _context.Sections.FirstOrDefaultAsync(s => s.Id == id);
		}

		public async Task<Section?> GetByName(string name)
        {
            return await _context.Sections.FirstOrDefaultAsync(s => s.Name == name);
        }
	}
}
