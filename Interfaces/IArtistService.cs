using GrammyAwards.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Interfaces
{
    public interface IArtistService
    {
        Task<Artist?> GetArtistByIdAsync(int id);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task AddArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        Task DeleteArtistAsync(int id);
    }
}