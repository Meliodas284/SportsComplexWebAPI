using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Models.Dto.Subscription;
using SportsComplexWebAPI.Repositories.AdministratorRepository;
using SportsComplexWebAPI.Repositories.CoachRepository;
using SportsComplexWebAPI.Repositories.SectionRepository;
using SportsComplexWebAPI.Repositories.SubscriptionRepository;
using SportsComplexWebAPI.Repositories.UserRepository;
using System.Data;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IMapper _mapper;
        private readonly IAdministratorRepository _adminRepository;
		private readonly IUserRepository _userRepository;

        public AdministratorService
        (
            IMapper mapper, 
            IAdministratorRepository adminRepository,
			IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
			_userRepository = userRepository;
        }

		public async Task<ResponseAPI<GetAdministratorDto>> Delete(int id)
		{
			var response = new ResponseAPI<GetAdministratorDto>();
			try
			{
				var admin = await _adminRepository.GetById(id);
				if (admin == null)
					throw new Exception("Administrator is not found");
				var user = await _userRepository.Get(admin);
				await _userRepository.Delete(user);
				response.Data = _mapper.Map<GetAdministratorDto>(admin);
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

		public async Task<ResponseAPI<GetAdministratorDto>> Get(int id)
		{
			var response = new ResponseAPI<GetAdministratorDto>();
			try
			{
				var admin = await _adminRepository.GetById(id);
				if (admin == null)
					throw new Exception("Administrator is not found");
				response.Data = _mapper.Map<GetAdministratorDto>(admin);
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

		public async Task<ResponseAPI<List<GetAdministratorDto>>> GetAll()
		{
			var response = new ResponseAPI<List<GetAdministratorDto>>();
			try
			{
				var admins = await _adminRepository.GetAll();
				if (admins.Count == 0)
					throw new Exception("Administrators are not found");
				response.Data = admins.Select(a => _mapper.Map<GetAdministratorDto>(a)).ToList();
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

		public async Task<ResponseAPI<GetAdministratorDto>> Register(RegisterAdministratorDto request)
		{
			var response = new ResponseAPI<GetAdministratorDto>();
			try
			{
				var admin = _mapper.Map<Administrator>(request);
				var user = new User
				{
					Username = request.Username,
					Password = request.Password,
					Role = "Administrator"
				};
				admin.User = user;
				response.Data = _mapper.Map<GetAdministratorDto>(await _adminRepository.Create(admin));
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

		public async Task<ResponseAPI<GetAdministratorDto>> Update(UpdateAdministratorDto request)
		{
			var response = new ResponseAPI<GetAdministratorDto>();
			try
			{
				var admin = await _adminRepository.Update(request);
				if (admin == null)
					throw new Exception("Administrator is not found");
				response.Data = _mapper.Map<GetAdministratorDto>(admin);
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
