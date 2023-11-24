using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUserPlaylistService _userPlaylistService;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IPlaylistSongService playlistSongService, IUserPlaylistService userPlaylistService)
        {
            _userPlaylistService = userPlaylistService;
            _playlistSongService = playlistSongService;
            _playlistRepository = playlistRepository;
        }

        public async Task<PlaylistEntity?> AddObjectAsync(PlaylistEntity obj)
        {
            var prefix = "PL";
            var lastesObj = (await GetAllObjectAsync())
                .Where(t => t.Id.Contains(prefix))
                .OrderByDescending(t => t.Id)
                .FirstOrDefault();
            var id = "";
            if (lastesObj == null)
            {
                id = prefix + 1.ToString("000");
            }
            else
            {
                var split = lastesObj.Id.Split(prefix);
                
                if (split.Count() <= 0)
                {
                    id = Guid.NewGuid().ToString();
                }
                else
                {
                    var temp = int.Parse(split[1]);
                    id = prefix + (++temp).ToString("000");
                }
            }
            
            obj.Id = id;
            obj.CreatedAt = DateTimeOffset.Now;
            return await _playlistRepository.AddObjectAsync(obj);
        }

        public async Task<List<PlaylistSongEntity>> AddSongsToPlaylist(List<PlaylistSongEntity> listItemsRequest)
        {
            return await _playlistSongService.AddMultiObjectsAsync(listItemsRequest);
        }

        public async Task<PlaylistEntity> CreatePlaylist(PlaylistEntity playlist, string userId)
        {
            var result = await AddObjectAsync(playlist);
            if (result != null)
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

        public async Task<PlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            await _playlistSongService.DeleteMultiObjectsByPlaylistIdAsync(id[0].ToString());
            return await _playlistRepository.DeleteObjectSync(id);
        }

        public async Task<PlaylistEntity> DeletePlaylist(string playlistId)
        {
            return await DeleteObjectSync(playlistId);
        }

        public async Task<List<PlaylistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _playlistRepository.GetAllObjectAsync(pageNumber, pageSize);
        }

        public async Task<PlaylistEntity?> GetObjectAsync(params object[] id)
        {
            return await _playlistRepository.GetObjectAsync(id);
        }

        public async Task<Pagination> GetPaginationByUserId(string songId, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _playlistRepository.GetCountAsync(songId);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<PlaylistEntity>> GetPlaylistsByUserId(string userId, int pageNumber = -1, int pageSize = -1)
        {
            return await _playlistRepository.GetPlaylistsByUserId(userId, pageNumber, pageSize);
        }

        public async Task<List<PlaylistSongEntity>> RemoveSongsFromPlaylist(List<string> songIds, string playlistId)
        {
            return await _playlistSongService.DeleteMultiObjectsBySongIdsAsync(songIds, playlistId);
            
        }

        public async Task<List<PlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            
            throw new NotImplementedException();

        }

        public async Task<PlaylistEntity?> UpdateObjectAsync(PlaylistEntity obj)
        {
            return await _playlistRepository.UpdateObjectAsync(obj);
        }
    }
}
