using Microsoft.IdentityModel.Tokens;
using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.UserDto;
using SportsComplexWebAPI.Repositories.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportsComplexWebAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

            var jwt = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                expires: DateTime.UtcNow.AddDays(7)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<ResponseAPI<string>> Login(LoginUserDto request)
        {
            var response = new ResponseAPI<string>();
            try
            {
                var user = await _userRepository.GetByNamePassword(request.Username, request.Password);
                if (user == null)
                    throw new Exception("Wrong username or password");
                response.Data = CreateToken(user);
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
