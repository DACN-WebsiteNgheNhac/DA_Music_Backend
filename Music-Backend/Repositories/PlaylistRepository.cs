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

        public async Task<PlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            return await DeleteAsync(id);
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

        public async Task<int> GetCountAsync(string query)
        {
            return await GetAllAsync().Result.Where(t => t.UserPlaylists.Any(t => t.UserId == query)).CountAsync();
        }

        public async Task<PlaylistEntity?> GetObjectAsync(params object[] id)
        {
            return await _context.Playlist.AsNoTracking()
                .Include(t => t.PlaylistSongs)
                .ThenInclude(t => t.Song)
                .ThenInclude(t => t.ArtistSongs)
                .ThenInclude(t => t.Artist).AsNoTracking()
                .Where(t => t.Id == id[0].ToString())
                .FirstOrDefaultAsync();
        }

        public async Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId, int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await _context.Playlist.AsNoTracking()
                    .Include(t => t.UserPlaylists)
                    .Include(t => t.PlaylistSongs)
                    .ThenInclude(t => t.Song)
                    .ThenInclude(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .Where(t => t.UserPlaylists.Any(t => t.UserId == userId))
                    .OrderByDescending(t => t.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            else
                return await _context.Playlist.AsNoTracking()
                    .Include(t => t.UserPlaylists)
                    .Include(t => t.PlaylistSongs)
                    .ThenInclude(t => t.Song)
                    .ThenInclude(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .Where(t => t.UserPlaylists.Any(t => t.UserId == userId))
                    .OrderByDescending(t => t.CreatedAt)
                    .ToListAsync();
        }

        public Task<List<PlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaylistEntity?> UpdateObjectAsync(PlaylistEntity obj)
        {
            return await UpdateAsync(obj);
        }
    }
}
