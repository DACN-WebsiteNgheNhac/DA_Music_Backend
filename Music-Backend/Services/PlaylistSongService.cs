using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly IPlaylistSongRepository _playlistSongRepository;

        public PlaylistSongService(IPlaylistSongRepository playlistSongRepository)
        {
            _playlistSongRepository = playlistSongRepository;
        }

        public async Task<List<PlaylistSongEntity>> AddMultiObjectsAsync(List<PlaylistSongEntity> data)
        {
            var createdDate = DateTimeOffset.Now;
            data = data.Select((data, index) => new PlaylistSongEntity
            {
                CreatedAt = createdDate,
                SongId = data.SongId,
                PlaylistId = data.PlaylistId
            }).ToList();
            return await _playlistSongRepository.AddMultiObjectsAsync(data);
        }

        public async Task<PlaylistSongEntity?> AddObjectAsync(PlaylistSongEntity obj)
        {
            return await _playlistSongRepository.AddObjectAsync(obj);
        }

        public Task<PlaylistSongEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaylistSongEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
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
