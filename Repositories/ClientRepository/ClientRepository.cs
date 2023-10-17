using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Client;

namespace SportsComplexWebAPI.Repositories.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Client> Create(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> Delete(int id)
        {
            var deleteClient = await GetById(id);
            if (deleteClient == null)
                return null;

            _context.Clients.Remove(deleteClient);
            await _context.SaveChangesAsync();
            return deleteClient;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client?> Update(UpdateClientDto request)
        {
            var client = await GetById(request.Id);
            if (client == null)
                return null;

            client.Name = request.Name;
            client.Surname = request.Surname;
            client.DateOfBirth = request.DateOfBirth;
            client.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
