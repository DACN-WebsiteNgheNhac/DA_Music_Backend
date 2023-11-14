using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IPlaylistRepository : IRepository<PlaylistEntity, PlaylistEntity>
    {
        Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId);
    }
}
