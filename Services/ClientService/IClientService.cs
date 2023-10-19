using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;

namespace SportsComplexWebAPI.Services.ClientService
{
    public interface IClientService
    {
        public Task<ResponseAPI<GetClientDto>> Register(RegisterClientDto request);
    }
}
