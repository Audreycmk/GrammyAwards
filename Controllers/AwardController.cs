using Microsoft.AspNetCore.Mvc;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrammyAwards.Controllers
{
    public class AwardsController : Controller
    {
        private readonly IAwardService _awardService;
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;

        public AwardsController(IAwardService awardService, ISongService songService, IArtistService artistService)
        {
            _awardService = awardService;
            _songService = songService;
            _artistService = artistService;
        }

        // GET: Awards/Index
        public async Task<IActionResult> Index()
        {
            var awards = await _awardService.GetAllAwardsAsync();
            return View(awards); // Returns /Views/Awards/Index.cshtml
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var award = await _awardService.GetAwardByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            return View(award); // Returns /Views/Awards/Details.cshtml
        }

        // GET: Awards/Create
        public async Task<IActionResult> Create()
        {
            // Retrieve the list of artists and songs for the dropdowns
            var artists = await _artistService.GetAllArtistsAsync();
            var songs = await _songService.GetAllSongsAsync();

            ViewBag.Artists = new SelectList(artists, "Id", "Name");
            ViewBag.Songs = new SelectList(songs, "Id", "Title");

            // Pass AwardStatus options to the view
            ViewBag.Statuses = new SelectList(System.Enum.GetValues(typeof(AwardStatus)));

            return View(); // Returns /Views/Awards/Create.cshtml
        }

        // POST: Awards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Award award)
        {
            if (ModelState.IsValid)
            {
                await _awardService.AddAwardAsync(award);
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, reload the dropdowns
            var artists = await _artistService.GetAllArtistsAsync();
            var songs = await _songService.GetAllSongsAsync();

            ViewBag.Artists = new SelectList(artists, "Id", "Name");
            ViewBag.Songs = new SelectList(songs, "Id", "Title");
            ViewBag.Statuses = new SelectList(System.Enum.GetValues(typeof(AwardStatus)));

            return View(award); // Returns /Views/Awards/Create.cshtml
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var award = await _awardService.GetAwardByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            // Retrieve the list of artists and songs for the dropdowns
            var artists = await _artistService.GetAllArtistsAsync();
            var songs = await _songService.GetAllSongsAsync();

            ViewBag.Artists = new SelectList(artists, "Id", "Name", award.Song?.ArtistId);
            ViewBag.Songs = new SelectList(songs, "Id", "Title", award.SongId);
            ViewBag.Statuses = new SelectList(System.Enum.GetValues(typeof(AwardStatus)), award.Status);

            return View(award); // Returns /Views/Awards/Edit.cshtml
        }

        // POST: Awards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Award award)
        {
            if (id != award.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _awardService.UpdateAwardAsync(award);
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, reload the dropdowns
            var artists = await _artistService.GetAllArtistsAsync();
            var songs = await _songService.GetAllSongsAsync();

            ViewBag.Artists = new SelectList(artists, "Id", "Name", award.Song?.ArtistId);
            ViewBag.Songs = new SelectList(songs, "Id", "Title", award.SongId);
            ViewBag.Statuses = new SelectList(System.Enum.GetValues(typeof(AwardStatus)), award.Status);

            return View(award); // Returns /Views/Awards/Edit.cshtml
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var award = await _awardService.GetAwardByIdAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            return View(award); // Returns /Views/Awards/Delete.cshtml
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _awardService.DeleteAwardAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}