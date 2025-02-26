using GrammyAwards.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrammyAwards.Interfaces
{
    public interface IAwardService
    {
        Task<Award?> GetAwardByIdAsync(int id);
        Task<IEnumerable<Award>> GetAllAwardsAsync();
        Task AddAwardAsync(Award award);
        Task UpdateAwardAsync(Award award);
        Task DeleteAwardAsync(int id);
    }
}