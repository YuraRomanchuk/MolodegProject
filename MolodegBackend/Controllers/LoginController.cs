using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public LoginController(IConfiguration configuration,
                               SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = _signInManager.UserManager.FindByNameAsync(login.Login);
            if (user.Result == null)
            {
                return BadRequest(new LoginResult { Successful = false, Errors = new List<string>() { "Логін не існує." } });
            }
            var result = await _signInManager.PasswordSignInAsync(user.Result.UserName, login.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new LoginResult { Successful = false, Errors = new List<string>() { "Пароль невірний." } });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true,  Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}