using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MolodegBackend.Domain.Services;
using MolodegBackend.Extensions;
using MolodegBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MolodegBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacardController : ControllerBase
    {
        private readonly IPlacardService _placardService;

        public PlacardController(IPlacardService placardService)
        {
            _placardService = placardService;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Post([FromBody]Placard placard)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            if (placard == null)
            {
                return BadRequest("Placard object is null");
            }

            await _placardService.AddPlacardAsync(placard);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<List<Placard>> GetPlacardsAsync()
        {
            return await _placardService.GetAllPlacardAsync();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _placardService.DeletePlacardAsync(id);
            return Ok();
        }
     }
}