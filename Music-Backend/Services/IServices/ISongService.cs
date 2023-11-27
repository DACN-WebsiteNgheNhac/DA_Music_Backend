using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface ISongService : IService<SongEntity>
    {
        Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize);

        Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize);
        Task<List<SongEntity>> GetSongsByArtistId(string artistId);
    }
}
