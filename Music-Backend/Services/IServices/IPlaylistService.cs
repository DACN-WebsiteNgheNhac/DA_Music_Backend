using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface IPlaylistService : IService<PlaylistEntity>
    {
        Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId, int pageNumber = -1, int pageSize = -1);
        Task<Pagination> GetPaginationByUserId(string userId, int pageNumber, int pageSize);

        Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId);
        Task<PlaylistEntity> DeletePlaylist(string playlistId);
        Task<List<PlaylistSongEntity>> AddSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest);
        Task<List<PlaylistSongEntity>> RemoveSongsFromPlaylist(List<string> songIds, string playlistId);
    }
}
