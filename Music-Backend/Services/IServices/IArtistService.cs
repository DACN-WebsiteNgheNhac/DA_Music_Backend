using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface IArtistService : IService<ArtistEntity>
    {
        Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize);
        Task<List<ArtistEntity>> GetTopArtistsAsync(int top = 5);

    }
}
