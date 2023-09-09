using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Dtos.Administrator;
using SportsComplexWebAPI.Models;
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


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> GetAdministrators()
        {
            var response = await _service.GetAdministrators();
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> GetSingleAdministrator(int id)
        {
            var response = await _service.GetSingleAdmin(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> RegisterAdmin(RegisterAdminDto request)
        {
            var response = await _service.RegisterAdmin(request);
            if (response.Data is null)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> PutAdmin(PutAdminDto request)
        {
            var response = await _service.PutAdministrator(request);
            if (response.Data is null)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> DeleteAdmin(int id)
        {
            var response = await _service.DeleteAdmin(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
