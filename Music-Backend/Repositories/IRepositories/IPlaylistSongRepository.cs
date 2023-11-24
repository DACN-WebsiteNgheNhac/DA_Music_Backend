using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IPlaylistSongRepository : IRepository<PlaylistSongEntity, PlaylistSongEntity>
    {
        Task<List<PlaylistSongEntity>> AddMultiObjectsAsync(List<PlaylistSongEntity> data);
        Task<List<PlaylistSongEntity>> DeleteMultiObjectsByPlaylistIdAsync(string playlistId);
        Task<List<PlaylistSongEntity>> DeleteMultiObjectsBySongIdsAsync(List<string> songIds, string playlistId);

    }
}
