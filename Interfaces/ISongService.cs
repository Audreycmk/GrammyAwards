using GrammyAwards.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Interfaces
{
    public interface ISongService
    {
        Task<Song?> GetSongByIdAsync(int id);
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task AddSongAsync(Song song);
        Task UpdateSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }
}