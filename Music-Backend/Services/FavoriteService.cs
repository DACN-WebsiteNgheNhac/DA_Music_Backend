using Music_Backend.Models.Entities;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public Task<FavoriteEntity?> AddObjectAsync(FavoriteEntity obj)
        {
            obj.CreatedAt = DateTimeOffset.Now;
            return _favoriteRepository.AddObjectAsync(obj);
        }

        public Task<FavoriteEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FavoriteEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite)
        {
            return await _favoriteRepository.RemoveSongFromFavoriteSongs(favorite);
        }

        public async Task<List<FavoriteEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _favoriteRepository.SearchObjectAsync(query, pageNumber, pageSize);    
        }

        public Task<FavoriteEntity?> UpdateObjectAsync(FavoriteEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
