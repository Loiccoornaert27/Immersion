using ImmersionApi.Data;
using ImmersionApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImmersionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "allConnections")] // On active la règle de CORS demandée 
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserFakeDB _dbUser;

        public AuthenticateController(IConfiguration configuration, UserFakeDB dbUser)
        {
            _configuration = configuration;
            _dbUser = dbUser;
        }

        [HttpPost("/authenticate")] // On se sert d'un string pour modifier la route par défaut en une route personnalisée 
        public IActionResult Authenticate([FromBody] Credential credential)
        {
            var user = _dbUser.GetAll().FirstOrDefault(x => x.Email == credential.Email && x.Password == credential.Password);
            
            
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, credential.Email),
                    new Claim(ClaimTypes.Email, credential.Email),
                    new Claim(ClaimTypes.Role, ((bool)user.IsAdmin ? "Admin" : "user"))
                };

                var expiresAt = DateTime.UtcNow.AddMinutes(30);

                return Ok(new
                {
                    token = CreateToken(claims, expiresAt),
                    expiresAt = expiresAt,
                });
            }

            ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint");
            return Unauthorized(ModelState);
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssuer"],
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
