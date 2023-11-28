using AutoMapper;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Client;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Repositories.ClientRepository;
using SportsComplexWebAPI.Repositories.UserRepository;

namespace SportsComplexWebAPI.Services.ClientService
{
	public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
		private readonly IUserRepository _userRepository;

        public ClientService
        (
            IMapper mapper, 
            IClientRepository clientRepository,
			IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
			_userRepository = userRepository;
        }

		public async Task<ResponseAPI<GetClientDto>> Delete(int id)
		{
			var response = new ResponseAPI<GetClientDto>();
			try
			{
				var client = await _clientRepository.GetById(id);
				if (client == null)
					throw new Exception("Client is not found");
				var user = await _userRepository.Get(client);
				await _userRepository.Delete(user);
				response.Data = _mapper.Map<GetClientDto>(client);
				return response;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Data = null;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetClientDto>> Get(int id)
		{
			var response = new ResponseAPI<GetClientDto>();
			try
			{
				var client = await _clientRepository.GetById(id);
				if (client == null)
					throw new Exception("Client is not found");
				response.Data = _mapper.Map<GetClientDto>(client);
				return response;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Data = null;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<List<GetClientDto>>> GetAll()
		{
			var response = new ResponseAPI<List<GetClientDto>>();
			try
			{
				var clients = await _clientRepository.GetAll();
				if (clients.Count == 0)
					throw new Exception("Clients are not found");
				response.Data = clients.Select(c => _mapper.Map<GetClientDto>(c)).ToList();
				return response;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Data = null;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetClientDto>> Register(RegisterClientDto request)
		{
			var response = new ResponseAPI<GetClientDto>();
			try
			{
				var client = _mapper.Map<Client>(request);
				var user = new User
				{
					Username = request.Username,
					Password = request.Password,
					Role = "Client"
				};
				client.User = user;
				response.Data = _mapper.Map<GetClientDto>(await _clientRepository.Create(client));
				return response;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Data = null;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseAPI<GetClientDto>> Update(UpdateClientDto request)
		{
			var response = new ResponseAPI<GetClientDto>();
			try
			{
				var client = await _clientRepository.Update(request);
				if (client == null)
					throw new Exception("Client is not found");
				response.Data = _mapper.Map<GetClientDto>(client);
				return response;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Data = null;
				response.Message = ex.Message;
				return response;
			}
		}
	}
}
