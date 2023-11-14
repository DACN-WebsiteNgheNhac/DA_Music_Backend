using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Music_Backend.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
           
        }

        public Task<AlbumEntity?> AddObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AlbumEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumEntity?> GetObjectAsync(params object[] id)
        {
            return await _albumRepository.GetObjectAsync(id);
        }

        public Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination?> GetPaginationByTopicId(string topicId, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _albumRepository.GetCountByTopicIdAsync(topicId);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<AlbumEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _albumRepository.SearchObjectAsync(query, pageNumber, pageSize);
        }

        public async Task<List<AlbumEntity>> SearchObjectByTopicIdAsync(string topicId, int pageNumber = -1, int pageSize = -1)
        {
            return await _albumRepository.SearchObjectByTopicIdAsync(topicId, pageNumber, pageSize);
        }

        public Task<AlbumEntity?> UpdateObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
