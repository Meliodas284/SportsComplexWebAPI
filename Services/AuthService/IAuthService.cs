using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.UserDto;

namespace SportsComplexWebAPI.Services.AuthService
{
    public interface IAuthService
    {
        public Task<ResponseAPI<string>> Login(LoginUserDto request);
        public string CreateToken(User user, int id);
    }
}
