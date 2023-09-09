using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Dtos.Authentication;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Services.AuthenticationService;

namespace SportsComplexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthenticationController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<string>>> Login(AuthUserDto request)
        {
            var response = await _service.Login(request);
            if (response.Data is null)
                return Unauthorized(response);
            return response;
        }
    }
}
