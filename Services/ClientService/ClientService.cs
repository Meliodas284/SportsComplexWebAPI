using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Models.Dto.GroupDto;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;
using SportsComplexWebAPI.Models.Dto.Subscription;
using SportsComplexWebAPI.Repositories.ClientRepository;
using SportsComplexWebAPI.Repositories.GroupRepository;
using SportsComplexWebAPI.Repositories.PurchasedSubscriptionRepository;
using SportsComplexWebAPI.Repositories.SubscriptionRepository;
using System.Security.Claims;

namespace SportsComplexWebAPI.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly ISubscriptionRepository _subRepository;
        private readonly IPurchasedSubscriptionRepository _purSubRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGroupRepository _groupRepository;

        public ClientService
        (
            IMapper mapper, 
            IClientRepository clientRepository, 
            ISubscriptionRepository subRepository, 
            IPurchasedSubscriptionRepository purSubRepository, 
            IHttpContextAccessor httpContextAccessor,
			IGroupRepository groupRepository
        )
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _subRepository = subRepository;
            _purSubRepository = purSubRepository;
            _httpContextAccessor = httpContextAccessor;
            _groupRepository = groupRepository;
        }

		public async Task<ResponseAPI<GetPurchasedSubscriptionDto>> BuySubscription(BuySubscriptionDto request)
		{
			var response = new ResponseAPI<GetPurchasedSubscriptionDto>();
            var clientId = int.Parse(_httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            try
            {
                var purchasedSub = _mapper.Map<PurchasedSubscription>(request);

                var group = await _groupRepository.GetById(request.GroupId);
                var subType = await _subRepository.GetById(request.SubscriptionId);
                if (subType!.Duration == "month")
                    purchasedSub.EndDate = purchasedSub.StartDate + TimeSpan.FromDays(30);
                else
                    purchasedSub.EndDate = DateTime.Now;

                purchasedSub.ClientId = clientId;
                purchasedSub.Subscription = subType;
                purchasedSub.Group = group!;
                await _purSubRepository.Create(purchasedSub);
                response.Data = _mapper.Map<GetPurchasedSubscriptionDto>(purchasedSub);
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

		public async Task<ResponseAPI<List<GetPurchasedSubscriptionDto>>> GetAllSubscriptons()
		{
            var response = new ResponseAPI<List<GetPurchasedSubscriptionDto>>();
			var clientId = int.Parse(_httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
			try
            {
                var purSubscriptions = await _purSubRepository.GetAllClientSub(clientId);
                if (purSubscriptions.Count == 0)
                    throw new Exception("Purchased subscriptions are not found");
                response.Data = purSubscriptions.Select(p => _mapper.Map<GetPurchasedSubscriptionDto>(p)).ToList();
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
                    Role = "Client", 
                };
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
