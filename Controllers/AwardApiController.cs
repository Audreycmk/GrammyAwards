using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GrammyAwards.Controllers
{
    [Route("api/[controller]")] // Base route for the API
    [ApiController] // Indicates that this is an API controller
    public class AwardsApiController : ControllerBase
    {
        private readonly IAwardService _awardService;
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;

        public AwardsApiController(IAwardService awardService, ISongService songService, IArtistService artistService)
        {
            _awardService = awardService;
            _songService = songService;
            _artistService = artistService;
        }

        // GET: api/AwardsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAwards()
        {
            var awards = await _awardService.GetAllAwardsAsync();
            return Ok(awards); // Return 200 OK with the list of awards
        }

        // GET: api/AwardsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetAward(int id)
        {
            var award = await _awardService.GetAwardByIdAsync(id);

            if (award == null)
            {
                return NotFound(); // Return 404 Not Found if the award is not found
            }

            return Ok(award); // Return 200 OK with the award
        }

        // POST: api/AwardsApi
        [HttpPost]
        public async Task<ActionResult<Award>> CreateAward(Award award)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _awardService.AddAwardAsync(award);
            return CreatedAtAction(nameof(GetAward), new { id = award.Id }, award); // Return 201 Created with the new award
        }

        // PUT: api/AwardsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAward(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest(); // Return 400 Bad Request if the IDs do not match
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _awardService.UpdateAwardAsync(award);
            return NoContent(); // Return 204 No Content for successful updates
        }

        // DELETE: api/AwardsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAward(int id)
        {
            var award = await _awardService.GetAwardByIdAsync(id);
            if (award == null)
            {
                return NotFound(); // Return 404 Not Found if the award is not found
            }

            await _awardService.DeleteAwardAsync(id);
            return NoContent(); // Return 204 No Content for successful deletions
        }
    }
}