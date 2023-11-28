using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.CoachDto;
using SportsComplexWebAPI.Services.CoachService;

namespace SportsComplexWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoachController : ControllerBase
	{
		private readonly ICoachService _coachService;

        public CoachController(ICoachService coachServise)
        {
			_coachService = coachServise;
        }

        [HttpGet]
		public async Task<ActionResult<ResponseAPI<List<GetCoachDto>>>> GetAll()
		{
			var response = await _coachService.GetAll();
			if (response.Data == null)
				return NotFound(response);
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResponseAPI<GetCoachDto>>> GetById(int id)
		{
			var response = await _coachService.Get(id);
			if (response.Data == null)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<ResponseAPI<GetCoachDto>>> Register(RegisterCoachDto request)
		{
			var response = await _coachService.Register(request);
			if (response.Data == null)
				return BadRequest(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ResponseAPI<GetCoachDto>>> Delete(int id)
		{
			var response = await _coachService.Delete(id);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}

		[HttpPut]
		public async Task<ActionResult<ResponseAPI<GetCoachDto>>> Update(UpdateCoachDto request)
		{
			var response = await _coachService.Update(request);
			if (response.Data == null)
				return NotFound(response);
			return response;
		}
	}
}
