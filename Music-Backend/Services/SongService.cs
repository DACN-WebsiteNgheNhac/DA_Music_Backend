using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _SongRepository;
        public SongService(ISongRepository SongRepository)
        {
            _SongRepository = SongRepository;
        }

        public async Task<SongEntity?> AddObjectAsync(SongEntity obj)
        {
            return await _SongRepository.AddObjectAsync(obj);
        }

        public async Task<SongEntity?> DeleteObjectSync(params object[] id)
        {
            return await _SongRepository.DeleteObjectSync(id);
        }

        public async Task<List<SongEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _SongRepository.GetAllObjectAsync(pageNumber, pageSize);
        }

        public async Task<SongEntity?> GetObjectAsync(params object[] id)
        {
            return await _SongRepository.GetObjectAsync(id);
        }

        public async Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _SongRepository.GetCountAsync();
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize)
        {
            return await _SongRepository.GetSongsByArea(area, pageNumber, pageSize);
        }

        public async Task<List<SongEntity>> GetSongsByArtistId(string artistId)
        {
            var data = await _SongRepository.GetSongsByArtistId(artistId);
            data.ForEach(t => t.ArtistSongs.Clear());
            return data;
        }

        public async Task<List<SongEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _SongRepository.SearchObjectAsync(query, pageNumber, pageSize);
        }

        public async Task<SongEntity?> UpdateObjectAsync(SongEntity obj)
        {
            return await _SongRepository.UpdateObjectAsync(obj);
        }
    }
}
