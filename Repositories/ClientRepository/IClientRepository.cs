using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Client;

namespace SportsComplexWebAPI.Repositories.ClientRepository
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAll();
        public Task<Client?> GetById(int id);
        public Task<Client> Create(Client client);
        public Task<Client?> Update(UpdateClientDto request);
        public Task<Client?> Delete(int id);
    }
}
