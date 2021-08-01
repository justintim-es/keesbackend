using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers
{
    [Route("api/kees")]
    public class KeesController : Controller {
        private readonly UserManager<IdentityUser> userManager;

        public KeesController(
            UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model) {
            if(!ModelState.IsValid) {
                return BadRequest("didn't supply enough arguments");
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("invalid email or password");
            var result = await userManager.CheckPasswordAsync(user, model.Password);
            if (result) {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("SOME MAGIC UNICORNS GENERATE THIS SECRET");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, "kees")
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var encryptedtoken = tokenHandler.WriteToken(token);
                return Ok(encryptedtoken);
            }
            return BadRequest("invalid email or password");
        }

    }
}