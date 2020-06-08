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
    public class SupportController : ControllerBase
    {
        private readonly ISupporterService _supporterService;
        private readonly IUserService _userService;
        private readonly IPlacardService _placardService;
        private readonly IMapper _mapper;
        public SupportController(ISupporterService supporterService, IMapper mapper, IUserService userService, IPlacardService placardService)
        {
            _supporterService = supporterService;
            _mapper = mapper;
            _placardService = placardService;
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupporterResourse supporter)
        {
            var user = await _userService.GetUserInfoAsync(supporter.UserId);
            var card = await _placardService.GetSpecificPlacardAsync(supporter.CardId);
            if (user == null || card == null )
            {
                return NotFound();
            }


            var resourse = _mapper.Map(supporter, new Supporter());
            await _supporterService.UpdateSupporter(resourse);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(string userId, int cardId)
        {
            var support = await _supporterService.GetSupporterAsync(userId, cardId);
            if (support == null)
            {
                return NotFound();
            }

            await _supporterService.DeleteSupporterAsync(userId, cardId);
            return Ok();
        }
    }
}