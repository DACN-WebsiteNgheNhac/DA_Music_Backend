using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistSongService _playlistSongService;

        public UserService(IPlaylistService playlistService
            , IPlaylistSongService playlistSongService)
        {
            _playlistService = playlistService;
            _playlistSongService = playlistSongService;
        }

        public Task<PlaylistSongEntity> AddSongsToPlaylist(ListItemsRequest<PlaylistSongEntity> listItemsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistEntity> DeletePlaylist(string playlistId)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistSongEntity> RemoveSongsToPlaylist(ListItemsRequest<PlaylistSongEntity> listItemsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
