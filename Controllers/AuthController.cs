using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Fake user list
        private static readonly List<TBLUsersRequestDto> FakeUsers = new List<TBLUsersRequestDto>
        {
            new TBLUsersRequestDto { kulAdi = "test1", kulSifre = "1234", extraParam = "admin" },
            new TBLUsersRequestDto { kulAdi = "test2", kulSifre = "5678", extraParam = "user" }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] TBLUsersRequestDto loginDto)
        {
            var user = FakeUsers.FirstOrDefault(u => u.kulAdi == loginDto.kulAdi && u.kulSifre == loginDto.kulSifre);
            if (user == null)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string GenerateJwtToken(TBLUsersRequestDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("super_secret_key_123!@#_jwt_token_key_2024");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.kulAdi),
                    new Claim(ClaimTypes.Role, user.extraParam ?? "user")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
} 