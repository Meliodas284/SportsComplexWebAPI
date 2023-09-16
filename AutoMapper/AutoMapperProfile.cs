using AutoMapper;
using SportsComplexWebAPI.Dtos.Administrator;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Administrator, GetAdminDto>();
            CreateMap<RegisterAdminDto, Administrator>();
            CreateMap<RegisterAdminDto, User>();
        }
    }
}
