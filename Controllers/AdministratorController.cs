using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.AdministratorDto;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Services.AdministratorService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _service;

        public AdministratorController(IAdministratorService service)
        {
            _service = service;
        }

        [HttpPost("registration/administrator")]
        public async Task<ActionResult<ResponseAPI<GetAdministratorDto>>> RegisterAdmin(RegisterAdministratorDto request)
        {
            var response = await _service.RegisterAdmin(request);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("registration/coach")]
        public async Task<ActionResult<ResponseAPI<GetCoachDto>>> RegisterCoach(RegisterCoachDto request)
        {
            var response = await _service.RegisterCoach(request);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
