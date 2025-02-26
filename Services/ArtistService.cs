using GrammyAwards.Data;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Services
{
    public class ArtistService(ApplicationDbContext context) : IArtistService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Artist?> GetArtistByIdAsync(int id)
        {
            return await _context.Artists
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artists
                .Include(a => a.Songs)
                .ToListAsync();
        }

        public async Task AddArtistAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }
    }
}