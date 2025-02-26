using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GrammyAwards.Controllers
{
    [Route("api/[controller]")] // Base route for the API
    [ApiController] // Indicates that this is an API controller
    public class ArtistsApiController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsApiController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: api/ArtistsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists); // Return 200 OK with the list of artists
        }

        // GET: api/ArtistsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);

            if (artist == null)
            {
                return NotFound(); // Return 404 Not Found if the artist is not found
            }

            return Ok(artist); // Return 200 OK with the artist
        }

        // POST: api/ArtistsApi
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _artistService.AddArtistAsync(artist);
            return CreatedAtAction(nameof(GetArtist), new { id = artist.Id }, artist); // Return 201 Created with the new artist
        }

        // PUT: api/ArtistsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest(); // Return 400 Bad Request if the IDs do not match
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _artistService.UpdateArtistAsync(artist);
            return NoContent(); // Return 204 No Content for successful updates
        }

        // DELETE: api/ArtistsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                return NotFound(); // Return 404 Not Found if the artist is not found
            }

            await _artistService.DeleteArtistAsync(id);
            return NoContent(); // Return 204 No Content for successful deletions
        }
    }
}