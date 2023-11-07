﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.ClientDto;
using SportsComplexWebAPI.Models.Dto.PurchasedSubscriptionDto;
using SportsComplexWebAPI.Services.ClientService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseAPI<GetClientDto>>> Register(RegisterClientDto request)
        {
            var response = await _service.Register(request);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("subscription/buy")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult<ResponseAPI<GetPurchasedSubscriptionDto>>> BuySubscription(BuySubscriptionDto request)
        {
            var response = await _service.BuySubscription(request);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
