using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Repositories.AdministratorRepository;
using SportsComplexWebAPI.Repositories.CoachRepository;
using SportsComplexWebAPI.Repositories.SectionRepository;
using System.Data;

namespace SportsComplexWebAPI.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IMapper _mapper;
        private readonly IAdministratorRepository _adminRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly ISectionRepository _sectionRepositroy;

        public AdministratorService
        (
            IMapper mapper, 
            IAdministratorRepository adminRepository, 
            ICoachRepository coachRepository,
            ISectionRepository sectionRepository
        )
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
            _coachRepository = coachRepository;
            _sectionRepositroy = sectionRepository;
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
                var section = await _sectionRepositroy.GetByName(request.SectionName);
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
