using Music_Backend.Models.Entities;
using Music_Backend.Services.IService;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IFavoriteRepository : IService<FavoriteEntity>
    {
        Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite);
    }
}
