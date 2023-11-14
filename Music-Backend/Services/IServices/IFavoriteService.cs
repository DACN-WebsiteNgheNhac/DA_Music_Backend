using Music_Backend.Models.Entities;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface IFavoriteService : IService<FavoriteEntity>
    {
        Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite);
    }
}
