using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;

namespace Music_Backend.Services.IServices
{
    public interface IUserService
    {
        //Task<UserEntity> LoginAsync(string username, string password);

        Task<UserEntity> GetObjectById(params object[] id);

        Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId);
        Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId);
        Task<PlaylistEntity> DeletePlaylist(string playlistId);
        Task<List<PlaylistSongEntity>> AddSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest);
        Task<PlaylistSongEntity> RemoveSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest);

        Task<CommentEntity> AddCommentAsync(CommentEntity comment);
        Task<CommentEntity> UpdateCommentAsync(CommentEntity comment);

        Task<List<FavoriteEntity>> GetFavoriteSongsByUserId(string userId);
        Task<FavoriteEntity> AddSongToFavoriteSongs(FavoriteEntity favorite);
        Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite);


    }
}
