using SportsComplexWebAPI.Dtos.Authentication;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Services.AuthenticationService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<string>> Login(AuthUserDto request);
        public string CreateToken(string username, string role);
    }
}
