using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using proje.Business.Abstract;
using proje.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService service;
        public AdminController(IAdminService _service)
        {
            service = _service;
        }
        [HttpPost]
        public IActionResult Post(Admin data)
        {
            var user = service.Get(x=>x.Name==data.Name && x.Password == data.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, data.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: "service", 
                    audience: "service",
                    claims: claims,
                    expires: DateTime.UtcNow.AddYears(1), 
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("servicetoflabscom")),
                            SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
                
            
        }
    }
}
