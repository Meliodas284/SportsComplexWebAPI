using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<User?> GetByNamePassword(string userName, string password);
        public Task<User> Get(Coach coach);
		public Task<User> Get(Administrator administrator);
		public Task<User> Get(Client client);
        public Task<bool> Delete(User user);
	}
}
