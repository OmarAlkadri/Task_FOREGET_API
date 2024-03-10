using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Task_FOREGET.Models;

namespace Task_FOREGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Context_DB _context;

        public AuthController(Context_DB context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null || string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginModel.UserName);

            bool isValidLogin = VerifyPassword(loginModel.Password, user.HashPassword);

            if (isValidLogin)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("N7eDz3kNQE6fu1ZeutZmwkC4jD+gGt8T4gicOtfjUqYIqEHfeuM9LxhG7T6neymU"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            else
            {
                return Unauthorized("Username or password is incorrect.");
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private string GenerateToken(Users user)
        {
            return "8gZp05K3DiVhFZh+O4Ttt+Ca7QBtQ8xaKyWckNM2Uw4hbB34dssdh2S81A4btNmH";
        }
    }
}
