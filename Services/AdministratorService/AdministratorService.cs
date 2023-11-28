using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Models.Dto.Subscription;
using SportsComplexWebAPI.Repositories.AdministratorRepository;
using SportsComplexWebAPI.Repositories.CoachRepository;
using SportsComplexWebAPI.Repositories.SectionRepository;
using SportsComplexWebAPI.Repositories.SubscriptionRepository;
using System.Data;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IMapper _mapper;
        private readonly IAdministratorRepository _adminRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly ISectionRepository _sectionRepositroy;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public AdministratorService
        (
            IMapper mapper, 
            IAdministratorRepository adminRepository, 
            ICoachRepository coachRepository,
            ISectionRepository sectionRepository,
            ISubscriptionRepository subscriptionRepository
        )
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
            _coachRepository = coachRepository;
            _sectionRepositroy = sectionRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<ResponseAPI<GetSubscriptionDto>> CreateSubscription(CreateSubscriptionDto request)
        {
            var response = new ResponseAPI<GetSubscriptionDto>();
            try
            {
                var subscription = _mapper.Map<Subscription>(request);
                await _subscriptionRepository.Create(subscription);
                response.Data = _mapper.Map<GetSubscriptionDto>(subscription);
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

        public async Task<ResponseAPI<List<GetSubscriptionDto>>> GetAllSubscriptions()
        {
            var response = new ResponseAPI<List<GetSubscriptionDto>>();
            try
            {
                var subscriptionList = await _subscriptionRepository.GetAll();
                response.Data = subscriptionList.Select(s => _mapper.Map<GetSubscriptionDto>(s)).ToList();
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

        public async Task<ResponseAPI<GetAdministratorDto>> RegisterAdmin(RegisterAdministratorDto request)
        {
            var response = new ResponseAPI<GetAdministratorDto>();
            try
            {
                var administrator = _mapper.Map<Administrator>(request);
                var user = new User
                {
                    Username = request.Username,
                    Password = request.Password,
                    Role = "Administrator"
                };
                administrator.User = user;
                await _adminRepository.Create(administrator);
                response.Data = _mapper.Map<GetAdministratorDto>(administrator);
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

        public async Task<ResponseAPI<GetCoachDto>> RegisterCoach(RegisterCoachDto request)
        {
            var response = new ResponseAPI<GetCoachDto>();
            try
            {
                var section = await _sectionRepositroy.GetById(request.SectionId);
                if (section == null)
                    throw new Exception("There is no section with the given name");

                var coach = _mapper.Map<Coach>(request);
                var user = new User 
                { 
                    Username = request.Username, 
                    Password = request.Password, 
                    Role = "Coach" 
                };
                coach.User = user;
                coach.Section = section;
                await _coachRepository.Create(coach);
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
