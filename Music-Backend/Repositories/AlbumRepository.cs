using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class AlbumRepository : BaseRepository<AlbumEntity>, IAlbumRepository
    {
        public async Task<AlbumEntity?> AddObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AlbumEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await GetAllAsync().Result.ToListAsync();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AlbumEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> UpdateObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
