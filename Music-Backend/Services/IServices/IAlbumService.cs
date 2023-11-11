using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface IAlbumService : IService<AlbumEntity>
    {
        Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize);
        Task<Pagination?> GetPaginationByTopicId(string topicId, int pageNumber, int pageSize);
        public Task<List<AlbumEntity>> SearchObjectByTopicIdAsync(string topicId, int pageNumber = -1, int pageSize = -1);
    }
}
