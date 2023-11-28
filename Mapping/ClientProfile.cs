using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;

namespace SportsComplexWebAPI.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
			CreateMap<Client, GetClientDto>();
			CreateMap<RegisterClientDto, Client>();
        }
    }
}
