using HR.WebApi.Models;
using HR.WebApi.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly HRAngularContext _context;

        public AuthController(HRAngularContext context)
        {
            _context = context;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] AuthenticateRequest employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid client request");
            }

            var password = Helpers.PasswordGenerator.GenerateHash(employee.Password);
            var emp = _context.Employees.FirstOrDefault(e => e.UserName == employee.UserName);
            var chech = _context.Employees.FirstOrDefault(e => e.UserName == employee.UserName && e.Password == password);
            if (chech != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://10.15.1.9:8080",
                    audience: "http://10.15.1.9:8080",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, Employee = chech });
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}
