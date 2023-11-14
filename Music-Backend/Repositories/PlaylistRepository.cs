using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class PlaylistRepository : BaseRepository<PlaylistEntity>, IPlaylistRepository
    {
        public async Task<PlaylistEntity?> AddObjectAsync(PlaylistEntity obj)
        {
            return await AddAsync(obj);
        }

        public Task<PlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlaylistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId)
        {
            return _context.Playlist
                .Include(t => t.UserPlaylists)
                .Include(t => t.PlaylistSongs)
                .ThenInclude(t => t.Song)
                .Where(t => t.UserPlaylists.Any(t => t.UserId == userId))
                .ToListAsync();
        }

        public Task<List<PlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistEntity?> UpdateObjectAsync(PlaylistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
