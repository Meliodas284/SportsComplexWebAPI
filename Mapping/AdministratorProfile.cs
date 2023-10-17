using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;

namespace SportsComplexWebAPI.Mapping
{
    public class AdministratorProfile : Profile
    {
        public AdministratorProfile()
        {
            CreateMap<ReadAdministratorDto, Administrator>();
        }
    }
}
