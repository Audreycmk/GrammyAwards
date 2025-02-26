using GrammyAwards.Data;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Services
{
    public class SongService : ISongService
    {
        private readonly ApplicationDbContext _context;

        public SongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Song?> GetSongByIdAsync(int id)
        {
            return await _context.Songs
                .Include(s => s.Artist)
                .Include(s => s.Awards)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Songs
                .Include(s => s.Artist)
                .Include(s => s.Awards)
                .ToListAsync();
        }

        public async Task AddSongAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSongAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }
    }
}