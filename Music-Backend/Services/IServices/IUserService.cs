using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;

namespace Music_Backend.Services.IServices
{
    public interface IUserService
    {
        //Task<UserEntity> LoginAsync(string username, string password);

        Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId);
        Task<PlaylistEntity> DeletePlaylist(string playlistId);
        Task<PlaylistSongEntity> AddSongsToPlaylist(ListItemsRequest<PlaylistSongEntity> listItemsRequest);
        Task<PlaylistSongEntity> RemoveSongsToPlaylist(ListItemsRequest<PlaylistSongEntity> listItemsRequest);

        
    }
}
