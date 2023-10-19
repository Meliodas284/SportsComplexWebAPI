using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Repositories.ClientRepository;

namespace SportsComplexWebAPI.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ResponseAPI<GetClientDto>> Register(RegisterClientDto request)
        {
            var response = new ResponseAPI<GetClientDto>();
            try
            {
                var client = _mapper.Map<Client>(request);
                var user = new User { Username = request.Username, Password = request.Password, Role = "Client"};
                client.User = user;
                await _clientRepository.Create(client);
                response.Data = _mapper.Map<GetClientDto>(client);
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
