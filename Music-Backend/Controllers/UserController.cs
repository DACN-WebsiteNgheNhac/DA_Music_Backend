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

        //[HttpGet]
        //[Route(WebApiEndPoint.Song.SearchSongs)]
        //public async Task<IActionResult> SearchSongsAsync(string? query, int pageNumber = -1, int pageSize = -1)
        //{
        //    var data = await _SongService.SearchObjectAsync(query, pageNumber, pageSize);
        //    var pagination = await _SongService.GetPagination(query, pageNumber, pageSize);
        //    return this.OkResponse<object>(
        //        _mapper.Map<List<SongResponse>>(data)
        //        , pagination: pagination);
        //}

        [HttpPost]
        [Route(WebApiEndPoint.User.CreatePlaylist)]
        public async Task<IActionResult> CreatePlaylistAsync(PlaylistRequest dataRequest, string userId)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _userService.CreatePlaylist(_mapper.Map<PlaylistEntity>(dataRequest), userId);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }

        [HttpPost]
        [Route(WebApiEndPoint.User.AddSongsToPlaylist)]
        public async Task<IActionResult> AddSongsToPlaylist(ListItemsRequest<PlaylistSongRequest> dataRequest)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _userService.AddSongsToPlaylist(_mapper.Map<ListItemsRequest<PlaylistSongEntity>>(dataRequest));
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }

    }
}
