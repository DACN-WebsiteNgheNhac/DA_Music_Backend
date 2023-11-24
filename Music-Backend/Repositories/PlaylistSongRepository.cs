using Microsoft.EntityFrameworkCore;
using Music_Backend.Exceptions;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class PlaylistSongRepository : BaseRepository<PlaylistSongEntity>, IPlaylistSongRepository
    {
        public async Task<List<PlaylistSongEntity>> AddMultiObjectsAsync(List<PlaylistSongEntity> data)
        {
            return await AddMultiAsync(data);
        }

        public async Task<PlaylistSongEntity?> AddObjectAsync(PlaylistSongEntity obj)
        {
            return await AddAsync(obj);
        }

        public async Task<List<PlaylistSongEntity>> DeleteMultiObjectsByPlaylistIdAsync(string playlistId)
        {
            var items = new List<PlaylistSongEntity>();
            try
            {
                items = await _context.PlaylistSong.Where(t => t.PlaylistId == playlistId).ToListAsync();
                _context.PlaylistSong.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new List<PlaylistSongEntity>();
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
            return items;
        }

        public async Task<List<PlaylistSongEntity>> DeleteMultiObjectsBySongIdsAsync(List<string> songIds, string playlistId)
        {
            var items = new List<PlaylistSongEntity>();
            try
            {
                items = await _context.PlaylistSong
                    .Where(t => t.PlaylistId == playlistId && songIds.Contains(t.SongId))
                    .ToListAsync();
                _context.PlaylistSong.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new List<PlaylistSongEntity>();
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
            return items;
        }

        public Task<PlaylistSongEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaylistSongEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistSongEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaylistSongEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistSongEntity?> UpdateObjectAsync(PlaylistSongEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
