using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Dtos.Administrator;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AdministratorService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetAdminDto>> DeleteAdmin(int id)
        {
            var response = new ServiceResponse<GetAdminDto>();
            try
            {
                var admin = await _context.Administrators.FirstOrDefaultAsync(a => a.Id == id);
                if (admin == null) 
                {
                    throw new Exception("Administrator is not found");
                }
                response.Data = _mapper.Map<GetAdminDto>(admin);
                _context.Administrators.Remove(admin);
                await _context.SaveChangesAsync();
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetAdminDto>>> GetAdministrators()
        {
            var response = new ServiceResponse<List<GetAdminDto>>();
            try
            {
                var admins = await _context.Administrators.ToListAsync();
                if (admins.Count() == 0)
                {
                    throw new Exception("Administrators is not found");
                }
                response.Data = admins.Select(a => _mapper.Map<GetAdminDto>(a)).ToList();
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;

                return response;
            }
        }

        public async Task<ServiceResponse<GetAdminDto>> GetSingleAdmin(int id)
        {
            var response = new ServiceResponse<GetAdminDto>();
            try
            {
                var admin = await _context.Administrators.FirstOrDefaultAsync(a => a.Id == id);
                if (admin is null)
                    throw new Exception("Administrator is not found!");
                response.Data = _mapper.Map<GetAdminDto>(admin);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetAdminDto>> PutAdministrator(PutAdminDto request)
        {
            var response = new ServiceResponse<GetAdminDto>();
            try
            {
                var admin = await _context.Administrators.FirstOrDefaultAsync(a => a.Id == request.Id);
                if (admin is null)
                {
                    throw new Exception("Administrator is not found");
                }
                admin.Name = request.Name;
                admin.Surname = request.Surname;
                admin.PassportNumber = request.PassportNumber;
                admin.PassportSeries = request.PassportSeries;
                admin.PhoneNumber = request.PhoneNumber;

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAdminDto>(admin);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetAdminDto>> RegisterAdmin(RegisterAdminDto request)
        {
            var response = new ServiceResponse<GetAdminDto>();
            try
            {
                var newUser = _mapper.Map<User>(request);
                newUser.Role = "Administrator";
                _context.Users.Add(newUser);
                var newAdmin = _mapper.Map<Administrator>(request);
                newAdmin.User = newUser;
                _context.Administrators.Add(newAdmin);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAdminDto>(newAdmin);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
