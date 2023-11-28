using AutoMapper;
using Microsoft.Identity.Client;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Repositories.CoachRepository;
using SportsComplexWebAPI.Repositories.SectionRepository;
using SportsComplexWebAPI.Repositories.UserRepository;

namespace SportsComplexWebAPI.Services.CoachService
{
	public class CoachService : ICoachService
	{
		private readonly IMapper _mapper;
		private readonly ICoachRepository _coachRepository;
		private readonly ISectionRepository _sectionRepository;
		private readonly IUserRepository _userRepository;

        public CoachService
		(
			ICoachRepository coachRepository, 
			IMapper mapper,
			ISectionRepository sectionRepository,
			IUserRepository userRepository
		)
        {
			_coachRepository = coachRepository;
			_mapper = mapper;
			_sectionRepository = sectionRepository;
			_userRepository = userRepository;
        }

        public async Task<ResponseAPI<GetCoachDto>> Delete(int id)
		{
			var response = new ResponseAPI<GetCoachDto>();
			try
			{
				var coach = await _coachRepository.GetById(id);
				if (coach == null)
					throw new Exception("Coach is not found!");
				var user = await _userRepository.Get(coach);
				await _userRepository.Delete(user);
				response.Data = _mapper.Map<GetCoachDto>(coach);
				return response;
			}
			catch (Exception ex)
			{
				response.Data = null;
				response.Success = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetCoachDto>> Get(int id)
		{
			var response = new ResponseAPI<GetCoachDto>();
			try
			{
				var coach = await _coachRepository.GetById(id);
				if (coach == null)
					throw new Exception("Coach is not found!");
				response.Data = _mapper.Map<GetCoachDto>(coach);
				return response;
			}
			catch (Exception ex)
			{
				response.Data = null;
				response.Success = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<List<GetCoachDto>>> GetAll()
		{
			var response = new ResponseAPI<List<GetCoachDto>>();
			try
			{
				var coaches = await _coachRepository.GetAll();
				if (coaches.Count == 0)
					throw new Exception("Coaches are not founded!");
				response.Data = coaches.Select(c => _mapper.Map<GetCoachDto>(c)).ToList();
				return response;
			}
			catch (Exception ex)
			{
				response.Data = null;
				response.Success = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetCoachDto>> Register(RegisterCoachDto request)
		{
			var response = new ResponseAPI<GetCoachDto>();
			try
			{
				var coach = _mapper.Map<Coach>(request);
				
				var section = await _sectionRepository.GetById(request.SectionId);
				if (section == null)
					throw new Exception("This section is not found!");
				coach.Section = section;

				var user = new User { Username =  request.Username, Password = request.Password, Role = "Coach"};
				coach.User = user;

				response.Data = _mapper.Map<GetCoachDto>(await _coachRepository.Create(coach));
				return response;
			}
			catch (Exception ex)
			{
				response.Data = null;
				response.Success = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetCoachDto>> Update(UpdateCoachDto request)
		{
			var response = new ResponseAPI<GetCoachDto>();
			try
			{
				var coach = await _coachRepository.Update(request);
				if (coach == null)
					throw new Exception("Coach is not found!");
				response.Data = _mapper.Map<GetCoachDto>(coach);
				return response;
			}
			catch (Exception ex)
			{
				response.Data = null;
				response.Success = false;
				response.Message = ex.Message;
				return response;
			}
		}
	}
}
