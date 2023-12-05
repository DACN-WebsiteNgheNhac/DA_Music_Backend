using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly IUserPlaylistService _userPlaylistService;
        private readonly ICommentService _commentService;
        private readonly IFavoriteService _favoriteService;

        public UserService(IUserRepository userRepository
            , IPlaylistService playlistService
            , IPlaylistSongService playlistSongService
            , IUserPlaylistService userPlaylistService
            , ICommentService commentService
            , IFavoriteService favoriteService)
        {
            _userRepository = userRepository;
            _playlistService = playlistService;
            _playlistSongService = playlistSongService;
            _userPlaylistService = userPlaylistService;
            _commentService = commentService;
            _favoriteService = favoriteService;
        }

        public async Task<CommentEntity> AddCommentAsync(CommentEntity comment)
        {
            return await _commentService.AddObjectAsync(comment);
        }

        public async Task<List<PlaylistSongEntity>> AddSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest)
        {
            return await _playlistSongService.AddMultiObjectsAsync(listItemsRequest);
        }

        public async Task<FavoriteEntity> AddSongToFavoriteSongs(FavoriteEntity favorite)
        {
            return await _favoriteService.AddObjectAsync(favorite);
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

        public async Task<List<FavoriteEntity>> GetFavoriteSongsByUserId(string userId)
        {
            return await _favoriteService.SearchObjectAsync(userId);
        }

        public async Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId)
        {
            return await _playlistService.GetPlaylistsByUserId(userId);
        }

        public Task<UserEntity> GetObjectById(params object[] id)
        {
            return _userRepository.GetObjectAsync(id);
        }

        public async Task<FavoriteEntity> RemoveSongFromFavoriteSongs(FavoriteEntity favorite)
        {
            return await _favoriteService.RemoveSongFromFavoriteSongs(favorite);
        }

        public Task<PlaylistSongEntity> RemoveSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentEntity> UpdateCommentAsync(CommentEntity comment)
        {
            return await _commentService.UpdateObjectAsync(comment);
        }
        public async Task<List<UserEntity>> GetAllObjectAsync()
        {
            return await _userRepository.GetAllObjectAsync();
        }

        public async Task<UserEntity> RegisterAsync(UserEntity obj)
        {
            var prefix = "U";
            var lastesObj = (await GetAllObjectAsync()).OrderByDescending(t => t.Id).FirstOrDefault();
            var split = lastesObj.Id.Split(prefix);
            var id = "";
            if (split.Count() <= 0)
            {
                id = Guid.NewGuid().ToString();
            }
            else
            {
                var temp = int.Parse(split[1]);
                id = prefix + (++temp).ToString("000");
            }
            obj.Id = id;
            obj.RoleId = "1";
            return await _userRepository.AddObjectAsync(obj);
        }

        public async Task<UserEntity> LoginAsync(string username, string password)
        {
            return await _userRepository.LoginAsync(username, password);
        }
    }
}
