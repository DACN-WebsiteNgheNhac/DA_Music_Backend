using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistService playlistService
            , IUserService userService
            , IMapper mapper)
        {
            _playlistService = playlistService;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get playlists by userId
        /// </summary>
        /// <param name="userId"> Input userId to search </param>
        /// <param name="pageNumber">Page number need go to</param>
        /// <param name="pageSize">Total entry in each page</param>
        [HttpGet]
        [Route(WebApiEndPoint.Playlist.GetPlaylistsByUserId)]
        public async Task<IActionResult> GetPlaylistsByUserId(string userId, int pageNumber = -1, int pageSize = -1)
        {
            var existedUser = await _userService.GetObjectById(userId);
            if(existedUser == null)
            {
                return NotFound(new BadResult("Not found user"));
            }

            var data = await _playlistService.GetPlaylistsByUserId(userId, pageNumber, pageSize);
            var pagination = await _playlistService.GetPaginationByUserId(userId, pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<PlaylistResponse>>(data)
                , pagination: pagination);
        }

        /// <summary>
        /// Get detail information of playlist by playlistId
        /// </summary>
        /// <param name="playlistId"> Input playlistId to get detail information of playlist </param>
        [HttpGet]
        [Route(WebApiEndPoint.Playlist.GetPlaylistByPlaylistId)]
        public async Task<IActionResult> GetPlaylistByPlaylistId(string playlistId)
        {
            var result = await _playlistService.GetObjectAsync(playlistId);
            if (result == null)
            {
                return NotFound(new BadResult("Not found user"));
            }
          
            return this.OkResponse<object>(_mapper.Map<PlaylistResponse>(result));
        }

        [HttpPost]
        [Route(WebApiEndPoint.Playlist.CreatePlaylist)]
        public async Task<IActionResult> CreatePlaylistAsync(PlaylistRequest dataRequest, string userId)
        {
            var existedUser = await _userService.GetObjectById(userId);
            if (existedUser == null)
            {
                return NotFound(new BadResult("Not found user"));
            }

            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _playlistService.CreatePlaylist(_mapper.Map<PlaylistEntity>(dataRequest), userId);
            return this.OkResponse<object>(_mapper.Map<PlaylistResponse>(result));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.Playlist.DeletePlaylist)]
        public async Task<IActionResult> DeletePlaylistAsync(string playlistId)
        {
            var existedPlaylist = await _playlistService.GetObjectAsync(playlistId);
            if (existedPlaylist == null)
            {
                return NotFound(new BadResult("Not found playlist"));
            }

            var result = await _playlistService.DeletePlaylist(playlistId);
            return this.OkResponse<object>(_mapper.Map<string>(result == null ? "Delete failed" : "Deleted successfully"));
        }


        [HttpPost]
        [Route(WebApiEndPoint.Playlist.AddSongsToPlaylist)]
        public async Task<IActionResult> AddSongsToPlaylist(List<string> songIds, string playlistId)
        {
            var existedPlaylist = await _playlistService.GetObjectAsync(playlistId);
            if (existedPlaylist == null)
            {
                return NotFound(new BadResult("Not found playlist"));
            }

            var data = songIds.Select((d, i) =>
                new PlaylistSongEntity
                {
                    SongId = d,
                    PlaylistId = playlistId
                }).ToList();
            var result = await _playlistService.AddSongsToPlaylist(data);
            return this.OkResponse<object>(_mapper.Map<List<PlaylistSongResponse>>(result));
        }

        [HttpPost]
        [Route(WebApiEndPoint.Playlist.RemoveSongsFromPlaylist)]
        public async Task<IActionResult> RemoveSongsFromPlaylist(List<string> songIds, string playlistId)
        {
            var existedPlaylist = await _playlistService.GetObjectAsync(playlistId);
            if (existedPlaylist == null)
            {
                return NotFound(new BadResult("Not found playlist"));
            }
           
            var result = await _playlistService.RemoveSongsFromPlaylist(songIds, playlistId);
            return this.OkResponse<object>(_mapper.Map<List<PlaylistSongResponse>>(result));
        }

        [HttpPut]
        [Route(WebApiEndPoint.Playlist.UpdatePlaylist)]
        public async Task<IActionResult> UpdatePlaylist(PlaylistRequest dataRequest, string playlistId)
        {
            var existedPlaylist = await _playlistService.GetObjectAsync(playlistId);
            if (existedPlaylist == null)
            {
                return NotFound(new BadResult("Not found playlist"));
            }

            var data = _mapper.Map<PlaylistEntity>(dataRequest);
            data.Id = playlistId;

            var result = await _playlistService.UpdateObjectAsync(data);
            return this.OkResponse<object>(_mapper.Map<PlaylistResponse>(result));
        }
    }
}
