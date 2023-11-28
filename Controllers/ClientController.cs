using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.Client;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;
using SportsComplexWebAPI.Services.ClientService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseAPI<List<GetClientDto>>>> GetAll()
        {
            var response = await _clientService.GetAll();
            if (response.Data == null)
                return NotFound(response);
            return response;
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ResponseAPI<GetClientDto>>> Get(int id)
		{
			var response = await _clientService.Get(id);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}

		[HttpPost]
		public async Task<ActionResult<ResponseAPI<GetClientDto>>> Register(RegisterClientDto request)
		{
			var response = await _clientService.Register(request);
			if (response.Data == null)
				return BadRequest(response);
			return response;
		}

		[HttpPut]
		public async Task<ActionResult<ResponseAPI<GetClientDto>>> Update(UpdateClientDto request)
		{
			var response = await _clientService.Update(request);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ResponseAPI<GetClientDto>>> Delete(int id)
		{
			var response = await _clientService.Delete(id);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}
	}
}
