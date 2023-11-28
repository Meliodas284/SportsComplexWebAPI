using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

		public async Task<bool> Delete(User user)
		{
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
		}

		public async Task<User> Get(Coach coach)
		{
            return await _context.Users.Include(u => u.Coach).FirstAsync(u => 
                u.Coach != null && u.Coach.Id == coach.Id);
		}

		public async Task<User> Get(Administrator administrator)
		{
            return await _context.Users.Include(u => u.Administrator).FirstAsync(u =>
                u.Administrator != null && u.Administrator.Id == administrator.Id);
		}

		public async Task<User> Get(Client client)
		{
            return await _context.Users.Include(u => u.Client).FirstAsync(u =>
                u.Client != null && u.Client.Id == client.Id);
		}

		public async Task<User?> GetByNamePassword(string userName, string password)
        {
            return await _context.Users
                .Include(u => u.Client)
                .Include(u => u.Coach)
                .Include(u => u.Administrator)
                .FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);
        }
    }
}
