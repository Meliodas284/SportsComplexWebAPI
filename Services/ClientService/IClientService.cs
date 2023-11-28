using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Client;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;

namespace SportsComplexWebAPI.Services.ClientService
{
    public interface IClientService
    {
        public Task<ResponseAPI<List<GetClientDto>>> GetAll();
        public Task<ResponseAPI<GetClientDto>> Get(int id);
        public Task<ResponseAPI<GetClientDto>> Register(RegisterClientDto request);
        public Task<ResponseAPI<GetClientDto>> Update(UpdateClientDto request);
        public Task<ResponseAPI<GetClientDto>> Delete(int id);
    }
}
