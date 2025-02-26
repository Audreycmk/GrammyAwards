using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrammyAwards.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;

        public SongsController(ISongService songService, IArtistService artistService)
        {
            _songService = songService;
            _artistService = artistService;
        }

        // GET: Songs/Index
        public async Task<IActionResult> Index()
        {
            var songs = await _songService.GetAllSongsAsync();
            return View(songs); // Returns /Views/Songs/Index.cshtml
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song); // Returns /Views/Songs/Details.cshtml
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            // Retrieve the list of artists for the dropdown
            var artists = await _artistService.GetAllArtistsAsync();
            ViewBag.Artists = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(artists, "Id", "Name");
            return View(); // Returns /Views/Songs/Create.cshtml
        }

        // POST: Songs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Song song)
        {
            if (ModelState.IsValid)
            {
                await _songService.AddSongAsync(song);
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, reload the artists dropdown
            var artists = await _artistService.GetAllArtistsAsync();
            ViewBag.Artists = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(artists, "Id", "Name");
            return View(song); // Returns /Views/Songs/Create.cshtml
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            // Retrieve the list of artists for the dropdown
            var artists = await _artistService.GetAllArtistsAsync();
            ViewBag.Artists = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(artists, "Id", "Name", song.ArtistId);
            return View(song); // Returns /Views/Songs/Edit.cshtml
        }

        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _songService.UpdateSongAsync(song);
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, reload the artists dropdown
            var artists = await _artistService.GetAllArtistsAsync();
            ViewBag.Artists = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(artists, "Id", "Name", song.ArtistId);
            return View(song); // Returns /Views/Songs/Edit.cshtml
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song); // Returns /Views/Songs/Delete.cshtml
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _songService.DeleteSongAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}