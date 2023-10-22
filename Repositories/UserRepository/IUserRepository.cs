using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<User?> GetByNamePassword(string userName, string password);
    }
}
