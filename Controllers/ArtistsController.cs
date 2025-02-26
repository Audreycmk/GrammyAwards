using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;

namespace GrammyAwards.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: Artist/Index
        public async Task<IActionResult> Index()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            ViewBag.Artists = artists; // Using ViewBag to pass data to the view
            return View(artists);
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new Exception("Artist not found"); // Throw exception if artist is not found
            }

            ViewData["Artist"] = artist; // Using ViewData to pass data to the view
            return View(artist);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                await _artistService.AddArtistAsync(artist);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = "Invalid data provided."; // Using ViewBag for error messages
            return View(artist);
        }

        // GET: Artist/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new Exception("Artist not found"); // Throw exception if artist is not found
            }

            ViewBag.Artist = artist; // Using ViewBag to pass data to the view
            return View(artist);
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                throw new Exception("Artist ID mismatch"); // Throw exception if IDs don't match
            }

            if (ModelState.IsValid)
            {
                await _artistService.UpdateArtistAsync(artist);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = "Invalid data provided."; // Using ViewBag for error messages
            return View(artist);
        }

        // GET: Artist/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null)
            {
                throw new Exception("Artist not found"); // Throw exception if artist is not found
            }

            ViewData["Artist"] = artist; // Using ViewData to pass data to the view
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _artistService.DeleteArtistAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}