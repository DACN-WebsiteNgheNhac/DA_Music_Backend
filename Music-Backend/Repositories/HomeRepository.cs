using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class HomeRepository : BaseRepository<HomeEntity>, IHomeRepository
    {
        public async Task<HomeEntity> GetHome()
        {
            return await GetAllAsync().Result.Where(t=>t.Active == true).FirstOrDefaultAsync();
        }
    }
}
