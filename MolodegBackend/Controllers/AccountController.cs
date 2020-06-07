using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MolodegBackend.Models;
using static MolodegBackend.Models.Register;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            var newUser = new User { UserName = model.Login};

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}