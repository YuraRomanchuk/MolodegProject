using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MolodegBackend.Domain.Services;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm]UserResourse userModel)
        {

            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var resourse = _mapper.Map(userModel, user);
            await _userService.UpdateUserAsync(resourse);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<UserInfo> GetUserInfoAsync(string id)
        {
            return await _userService.GetUserInfoAsync(id);
        }
    }
}