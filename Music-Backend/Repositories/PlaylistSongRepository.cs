using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Repositories
{
    public class PlaylistSongRepository : BaseRepository<PlaylistSongEntity>, IPlaylistSongRepository
    {
        public async Task<PlaylistSongEntity?> AddObjectAsync(PlaylistSongEntity obj)
        {
            return await AddAsync(obj);
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
