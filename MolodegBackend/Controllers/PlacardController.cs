﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MolodegBackend.Domain.Services;
using MolodegBackend.Extensions;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacardController : ControllerBase
    {
        private readonly IPlacardService _placardService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public PlacardController(IPlacardService placardService, IMapper mapper, IUserService userService)
        {
            _placardService = placardService;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Post([FromForm] PlacardResourse placardModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            if (placardModel == null)
            {
                return BadRequest("Placard object is null");
            }
            var placard = new Placard() { CreatedDate = DateTime.Now.ToLocalTime().ToString() };

            if (placardModel.Picture != null)
            {
                placard.Picture = placardModel.Picture.ConvertToByteArray();
            }

            var resources = _mapper.Map(placardModel, placard);
            await _placardService.AddPlacardAsync(resources);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<List<PlacardInfo>> GetPlacardsAsync(string search, int page = 1) 
        {
            List<Placard> placards;
            if (search != null)
            {
                placards = await _placardService.GetPlacardsByNameAsync(search);
            }
            else
            {
                placards = await _placardService.GetAllPlacardAsync();
            }
            var resourse = _mapper.Map(placards, new List<PlacardInfo>());
            foreach(var item in resourse)
            {
                var user = await _userService.GetUserAsync(item.UserId);
                item.UserPicture = user.ProfilePicture;
                item.UserName = user.Name;
                item.UserLogin = user.UserName;
            }
            resourse = resourse.Skip(2 * (page - 10)).Take(10).ToList();
            return resourse;
        }

        [HttpGet("{id}")]
        public async Task<PlacardInfo> GetPlacardInfoAsync(int id)
        {
            var placard = await _placardService.GetSpecificPlacardAsync(id);
            var user = await _userService.GetUserAsync(placard.UserId);
            var resourse = _mapper.Map(placard, new PlacardInfo());
            resourse.UserPicture = user.ProfilePicture;
            resourse.UserName = user.Name;
            resourse.UserLogin = user.UserName;
            return resourse;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm]PlacardResourse placardModel)
        {
            var placard = await _placardService.GetSpecificPlacardAsync(id);
            if (placard == null)
            {
                return NotFound();
            }

            if (placardModel.Picture != null)
            {
                placard.Picture = placardModel.Picture.ConvertToByteArray();
            }

            var resourse = _mapper.Map(placardModel, placard);
            await _placardService.UpdatePlacardAsync(resourse);

            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id)
        {
            await _placardService.DeletePlacardAsync(id);
            return Ok();
        }
     }
}