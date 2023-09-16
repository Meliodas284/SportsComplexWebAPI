using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportsComplexWebAPI.Data;
using SportsComplexWebAPI.Dtos.Authentication;
using SportsComplexWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportsComplexWebAPI.Services.AuthenticationService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(AuthUserDto request)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync
                    (
                        u => u.Username == request.Username && u.Password == request.Password
                    );

                if (user is null)
                    throw new Exception("Wrong username or password!");

                response.Data = CreateToken(user.Username, user.Role);
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

        public string CreateToken(string username, string role)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

            var jwt = new JwtSecurityToken
                (
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
