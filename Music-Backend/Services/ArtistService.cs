using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public Task<ArtistEntity?> AddObjectAsync(ArtistEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArtistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _artistRepository.GetCountAsync(query);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<ArtistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _artistRepository.SearchObjectAsync(query, pageNumber, pageSize);
        }

        public Task<ArtistEntity?> UpdateObjectAsync(ArtistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
