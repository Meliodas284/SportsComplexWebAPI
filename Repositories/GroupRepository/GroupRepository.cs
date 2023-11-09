using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.GroupDto;

namespace SportsComplexWebAPI.Repositories.GroupRepository
{
	public class GroupRepository : IGroupRepository
	{
		private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Group> Create(Group group)
		{
			_context.Groups.Add(group);
			await _context.SaveChangesAsync();
			return group;
		}

		public async Task<Group?> Delete(int id)
		{
			var group = await GetById(id);
			if (group == null)
				return null;
			_context.Groups.Remove(group);
			await _context.SaveChangesAsync();
			return group;
		}

		public async Task<List<Group>> GetAll()
		{
			return await _context.Groups.Include(g => g.Coach).ToListAsync();
		}

		public async Task<Group?> GetById(int id)
		{
			return await _context.Groups.Include(g => g.Coach).FirstOrDefaultAsync(g => g.Id == id);
		}

		public async Task<Group?> Update(UpdateGroupDto request)
		{
			var group = await GetById(request.Id);
			if (group == null)
				return null;
			group.Description = request.Description;
			group.Name = request.Name;
			group.CoachId = request.CoachId;
			await _context.SaveChangesAsync();
			return group;
		}
	}
}
