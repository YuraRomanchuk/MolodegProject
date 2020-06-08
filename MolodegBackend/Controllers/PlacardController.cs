using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MolodegBackend.Domain.Services;
using MolodegBackend.Extensions;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacardController : ControllerBase
    {
        private readonly IPlacardService _placardService;
        private readonly IMapper _mapper;
        public PlacardController(IPlacardService placardService, IMapper mapper)
        {
            _placardService = placardService;
            _mapper = mapper;
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
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(placardModel.Picture.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)placardModel.Picture.Length);
                }
                placard.Picture = imageData;
            }

            var resources = _mapper.Map(placardModel, placard);
            await _placardService.AddPlacardAsync(resources);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<List<Placard>> GetPlacardsAsync()
        {
            return await _placardService.GetAllPlacardAsync();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PlacardResourse placardModel)
        {
            var placard = await _placardService.GetSpecificPlacardAsync(id);
            if (placard == null)
            {
                return NotFound();
            }

            await _placardService.UpdatePlacardAsync(placard);

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