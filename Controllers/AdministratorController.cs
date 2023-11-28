using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Models.Dto.Subscription;
using SportsComplexWebAPI.Services.AdministratorService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _adminService;

        public AdministratorController(IAdministratorService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseAPI<List<GetAdministratorDto>>>> GetAll()
        {
            var response = await _adminService.GetAll();
            if (response.Data == null)
                return NotFound(response);
            return response;
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<ResponseAPI<GetAdministratorDto>>> Get(int id)
		{
			var response = await _adminService.Get(id);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}

		[HttpPost]
		public async Task<ActionResult<ResponseAPI<GetAdministratorDto>>> Register(RegisterAdministratorDto request)
		{
			var response = await _adminService.Register(request);
			if (response.Data == null)
				return BadRequest(response);
			return response;
		}

		[HttpPut]
		public async Task<ActionResult<ResponseAPI<GetAdministratorDto>>> Update(UpdateAdministratorDto request)
		{
			var response = await _adminService.Update(request);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ResponseAPI<GetAdministratorDto>>> Delete(int id)
		{
			var response = await _adminService.Delete(id);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}
	}
}
