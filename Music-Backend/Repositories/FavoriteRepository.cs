using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class FavoriteRepository : BaseRepository<FavoriteEntity>, IFavoriteRepository
    {
        public async Task<FavoriteEntity?> AddObjectAsync(FavoriteEntity obj)
        {
            return await AddAsync(obj);
        }

        public async Task<FavoriteEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite)
        {
            return await DeleteAsync(favorite.SongId, favorite.UserId);
        }

        public async Task<List<FavoriteEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<FavoriteEntity, bool>> predicate =
              t => t.UserId.Contains(query)
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.Song)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(predicate)
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.Song)
                    .ToListAsync();
        }

        public Task<FavoriteEntity?> UpdateObjectAsync(FavoriteEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
