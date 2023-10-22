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

        public async Task<User?> GetByNamePassword(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);
        }
    }
}
