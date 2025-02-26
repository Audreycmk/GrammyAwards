using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GrammyAwards.Controllers
{
    [Route("api/[controller]")] // Base route for the API
    [ApiController] // Indicates that this is an API controller
    public class SongsApiController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;

        public SongsApiController(ISongService songService, IArtistService artistService)
        {
            _songService = songService;
            _artistService = artistService;
        }

        // GET: api/SongsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs); // Return 200 OK with the list of songs
        }

        // GET: api/SongsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song == null)
            {
                return NotFound(); // Return 404 Not Found if the song is not found
            }

            return Ok(song); // Return 200 OK with the song
        }

        // POST: api/SongsApi
        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _songService.AddSongAsync(song);
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song); // Return 201 Created with the new song
        }

        // PUT: api/SongsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest(); // Return 400 Bad Request if the IDs do not match
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model state is invalid
            }

            await _songService.UpdateSongAsync(song);
            return NoContent(); // Return 204 No Content for successful updates
        }

        // DELETE: api/SongsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound(); // Return 404 Not Found if the song is not found
            }

            await _songService.DeleteSongAsync(id);
            return NoContent(); // Return 204 No Content for successful deletions
        }
    }
}