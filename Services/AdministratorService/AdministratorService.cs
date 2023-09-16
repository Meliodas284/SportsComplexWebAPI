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
                var user = await _context.Users.Include(u => u.Administrator).FirstOrDefaultAsync
                    (
                        u => u.Administrator != null && u.Administrator.Id == id
                    );

                if (user is null)
                    throw new Exception("Administrator is not found");

                response.Data = _mapper.Map<GetAdminDto>(user.Administrator);
                _context.Users.Remove(user);
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
                var user = await _context.Users.Include(u => u.Administrator).FirstOrDefaultAsync
                    (
                        u => u.Administrator != null && u.Administrator.Id == id
                    );
                if (user is null)
                    throw new Exception("Administrator is not found");
                response.Data = _mapper.Map<GetAdminDto>(user.Administrator);
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
                var user = await _context.Users.Include(u => u.Administrator).FirstOrDefaultAsync
                    (
                        u => u.Administrator != null && u.Administrator.Id == request.Id
                    );
                if (user is null)
                {
                    throw new Exception("Administrator is not found");
                }
                user.Administrator!.Name = request.Name;
                user.Administrator.Surname = request.Surname;
                user.Administrator.PassportNumber = request.PassportNumber;
                user.Administrator.PassportSeries = request.PassportSeries;
                user.Administrator.PhoneNumber = request.PhoneNumber;

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAdminDto>(user.Administrator);
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
