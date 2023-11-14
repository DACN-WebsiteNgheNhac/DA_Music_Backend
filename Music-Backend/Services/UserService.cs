using Music_Backend.Models.Entities;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly IUserPlaylistService _userPlaylistService;

        public UserService(IPlaylistService playlistService
            , IPlaylistSongService playlistSongService
            , IUserPlaylistService userPlaylistService)
        {
            _playlistService = playlistService;
            _playlistSongService = playlistSongService;
            _userPlaylistService = userPlaylistService;
        }

        public async Task<List<PlaylistSongEntity>> AddSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest)
        {
            return await _playlistSongService.AddMultiObjectsAsync(listItemsRequest);
        }

        public async Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId)
        {
            var result = await _playlistService.AddObjectAsync(playlist);
            if(result != null)
            {
                await _userPlaylistService.AddObjectAsync(
                    new UserPlaylistEntity 
                    { 
                        UserId = userId, 
                        PlaylistId = result.Id
                    });
            }
            return result;
        }

        public Task<PlaylistEntity> DeletePlaylist(string playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId)
        {
            return await _playlistService.GetPlaylistsByUserId(userId);
        }

        public Task<PlaylistSongEntity> RemoveSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
