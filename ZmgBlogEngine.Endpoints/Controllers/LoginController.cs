using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Repositories;
using ZmgBlogEngine.Services;

namespace ZmgBlogEngine.Endpoints.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;
        IConfiguration _configuration;

		public LoginController(ILoginService loginService, IConfiguration configuration)
		{
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public string Login(int userId, string password)
        {
            var user = _loginService.GetUserByIdAndPassword(userId, password);

            if (user != null)
            {
                return CreateToken(user);
            }

            return String.Empty;
        }

        private string CreateToken(UserDto userDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDto.Name),
                new Claim(ClaimTypes.Role, userDto.Rol.Name!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!
                ));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    audience: "http://localhost:5087",
                    issuer: "dotnet-user-jwts",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

