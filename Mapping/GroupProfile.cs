using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.GroupDto;

namespace SportsComplexWebAPI.Mapping
{
	public class GroupProfile : Profile
	{
        public GroupProfile()
        {
            CreateMap<Group, GetGroupDto>()
                .ForMember(dest => dest.Coach, opt => opt.MapFrom(src => src.Coach));
        }
    }
}
