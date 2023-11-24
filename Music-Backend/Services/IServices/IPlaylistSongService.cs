using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface IPlaylistSongService : IService<PlaylistSongEntity>
    {
        Task<List<PlaylistSongEntity>> AddMultiObjectsAsync(List<PlaylistSongEntity> data);
        Task<List<PlaylistSongEntity>> DeleteMultiObjectsByPlaylistIdAsync(string playlistId);
        Task<List<PlaylistSongEntity>> DeleteMultiObjectsBySongIdsAsync(List<string> songIds, string playlistId);
    }
}
