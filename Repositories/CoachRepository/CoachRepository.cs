using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.CoachDto;

namespace SportsComplexWebAPI.Repositories.CoachRepository
{
    public class CoachRepository : ICoachRepository
    {
        private readonly DataContext _context;

        public CoachRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Coach> Create(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
            return coach;
        }

        public async Task<Coach?> Delete(int id)
        {
            var deleteCoach = await GetById(id);
            if (deleteCoach == null)
                return null;
            _context.Coaches.Remove(deleteCoach);
            await _context.SaveChangesAsync();
            return deleteCoach;
        }

        public async Task<List<Coach>> GetAll()
        {
            return await _context.Coaches.Include(c => c.Section).ToListAsync();
        }

        public async Task<Coach?> GetById(int id)
        {
            return await _context.Coaches.Include(c => c.Section).FirstOrDefaultAsync(c => c.Id == id);
        }

		public async Task<Coach?> Update(UpdateCoachDto request)
        {
            var coach = await GetById(request.Id);
            if (coach == null)
                return null;
            coach.Name = request.Name;
            coach.Surname = request.Surname;
            coach.DateOfBirth = request.DateOfBirth;
            coach.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync();
            return coach;
        }
    }
}
