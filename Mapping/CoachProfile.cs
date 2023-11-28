using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.CoachDto;

namespace SportsComplexWebAPI.Mapping
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
			CreateMap<Coach, GetCoachDto>();
			CreateMap<RegisterCoachDto, Coach>();
        }
    }
}
