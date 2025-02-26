using GrammyAwards.Data;
using GrammyAwards.Interfaces;
using GrammyAwards.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Services
{
    public class AwardService : IAwardService
    {
        private readonly ApplicationDbContext _context;

        public AwardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Award?> GetAwardByIdAsync(int id)
        {
            return await _context.Awards
                .Include(a => a.Song) // Include Song
                .ThenInclude(s => s.Artist) // Include Artist for the Song
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Award>> GetAllAwardsAsync()
        {
            return await _context.Awards
                .Include(a => a.Song) // Include Song
                .ThenInclude(s => s.Artist) // Include Artist for the Song
                .ToListAsync();
        }

        public async Task AddAwardAsync(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAwardAsync(Award award)
        {
            _context.Awards.Update(award);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAwardAsync(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            if (award != null)
            {
                _context.Awards.Remove(award);
                await _context.SaveChangesAsync();
            }
        }
    }
}