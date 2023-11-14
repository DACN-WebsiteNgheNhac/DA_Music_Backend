using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService
            , IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndPoint.User.GetPlaylistsByUserId)]
        public async Task<IActionResult> GetAllPlaylistsByUserId(string userId)
        {
            var result = await _userService.GetPlaylistsByUserId(userId);
            return this.OkResponse<object>(_mapper.Map<List<PlaylistResponse>>(result));
        }

        [HttpPost]
        [Route(WebApiEndPoint.User.CreatePlaylist)]
        public async Task<IActionResult> CreatePlaylistAsync(PlaylistRequest dataRequest, string userId)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _userService.CreatePlaylist(_mapper.Map<PlaylistEntity>(dataRequest), userId);
            return this.OkResponse<object>(_mapper.Map<PlaylistResponse>(result));
        }

      
        [HttpPost]
        [Route(WebApiEndPoint.User.AddSongsToPlaylist)]
        public async Task<IActionResult> AddSongsToPlaylist(List<string> songIds, string playlistId)
        {
            var validate = this.CheckDataRequest(songIds);
            if (validate != null)
                return validate;
            var data = songIds.Select((d, i) =>
                new PlaylistSongEntity
                {
                    SongId = d,
                    PlaylistId = playlistId
                }).ToList();
            var result = await _userService.AddSongsToPlaylist(data);
            return this.OkResponse<object>(_mapper.Map<List<PlaylistSongResponse>>(result));
        }

    }
}
