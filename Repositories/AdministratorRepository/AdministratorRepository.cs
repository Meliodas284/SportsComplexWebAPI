using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;

namespace SportsComplexWebAPI.Repositories.AdministratorRepository
{
    public class AdministratorRepository : IAdministratorRepository
    {

        private readonly DataContext _context;
        public AdministratorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Administrator> Create(Administrator administrator)
        {
            _context.Administartors.Add(administrator);
            await _context.SaveChangesAsync();
            return administrator;
        }

        public async Task<Administrator?> Delete(int id)
        {
            var deleteAdministrator = await GetById(id);
            if (deleteAdministrator == null)
                return null;

            _context.Administartors.Remove(deleteAdministrator);
            await _context.SaveChangesAsync();
            return deleteAdministrator;
        }

        public async Task<List<Administrator>> GetAll()
        {
            return await _context.Administartors.ToListAsync();
        }

        public async Task<Administrator?> GetById(int id)
        {
            return await _context.Administartors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Administrator?> Update(UpdateAdministratorDto request)
        {
            var admin = await GetById(request.Id);
            if (admin == null)
                return null;

            admin.Name = request.Name;
            admin.Surname = request.Surname;
            admin.DateOfBirth = request.DateOfBirth;
            admin.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync();
            return admin;
        }
    }
}
