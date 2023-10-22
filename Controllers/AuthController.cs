using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.UserDto;
using SportsComplexWebAPI.Services.AuthService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseAPI<string>>> LoginUser(LoginUserDto request)
        {
            var response = await _service.Login(request);
            if (response.Data == null)
                return Unauthorized(response);
            return Ok(response);
        }
    }
}
