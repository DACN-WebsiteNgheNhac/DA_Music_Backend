using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
     
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _SongService;
        private readonly IMapper _mapper;

        public SongController(ISongService SongService, IMapper mapper)
        {
            _SongService = SongService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Songs
        /// </summary>
        /// <param name="pageNumber">Page number need go to</param>
        /// <param name="pageSize">Total entry in each page</param>
        [HttpGet]
        [Route(WebApiEndPoint.Song.GetAllSongs)]
        public async Task<IActionResult> GetAllSongsAsync(int pageNumber = -1, int pageSize = -1)
        {
            var data = await _SongService.GetAllObjectAsync(pageNumber, pageSize);
            var pagination = await _SongService.GetPagination("", pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<SongResponse>>(data)
                , pagination: pagination);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetSongById)]
        public async Task<IActionResult> GetSongsByIdAsync(string id)
        {
            var validate = this.CheckDataRequest(id);
            if (validate != null)
                return validate;
            var data = await _SongService.GetObjectAsync(id);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(data));
        }

        /// <summary>
        /// Search Song by title song, real name of artist, artist name
        /// </summary>
        /// <param name="query"> Input title song, real name of artist, artist name Song to search </param>
        /// <param name="pageNumber">Page number need go to</param>
        /// <param name="pageSize">Total entry in each page</param>
        [HttpGet]
        [Route(WebApiEndPoint.Song.SearchSongs)]
        public async Task<IActionResult> SearchSongsAsync(string? query, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _SongService.SearchObjectAsync(query, pageNumber, pageSize);
            var pagination = await _SongService.GetPagination(query, pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<SongResponse>>(data)
                , pagination: pagination);
        }

        [HttpPost]
        [Route(WebApiEndPoint.Song.CreateSong)]
        public async Task<IActionResult> CreateSong(SongRequest dataRequest)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _SongService.AddObjectAsync(_mapper.Map<SongEntity>(dataRequest));
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }


        [HttpPut]
        [Route(WebApiEndPoint.Song.UpdateSong)]
        public async Task<IActionResult> UpdateSong(SongRequest dataRequest, string id)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var rowEntity = _mapper.Map<SongEntity>(dataRequest);
            rowEntity.Id = id;
            var result = await _SongService.UpdateObjectAsync(rowEntity);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.Song.DeleteSong)]
        public async Task<IActionResult> DeleteSong(string id)
        {
            var result = await _SongService.DeleteObjectSync(id);
            if (result == null)
                return this.FailedActionDelete();
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }
    }
}
