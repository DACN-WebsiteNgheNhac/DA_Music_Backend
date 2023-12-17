using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Music_Backend.Utils.Const.WebApiEndPoint;

namespace Music_Backend.Controllers
{
     
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public SongController(ISongService songService
            , IArtistService artistService
            , IMapper mapper)
        {
            _songService = songService;
            _artistService = artistService;
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
            var data = await _songService.GetAllObjectAsync(pageNumber, pageSize);
            var pagination = await _songService.GetPagination("", pageNumber, pageSize);
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
            var data = await _songService.GetObjectAsync(id);
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
            var data = await _songService.SearchObjectAsync(query, pageNumber, pageSize);
            var pagination = await _songService.GetPagination(query, pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<SongResponse>>(data)
                , pagination: pagination);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetSongsByArtistId)]
        public async Task<IActionResult> GetSongsByArtistIdAsync(string artistId)
        {
            var existedArtist = await _artistService.GetArtistsById(new string[] { artistId });
            if (existedArtist == null || existedArtist.Count == 0)
            {
                return NotFound(new BadResult("Not found artist"));
            }

            var data = await _songService.GetSongsByArtistId(artistId);
            return this.OkResponse<object>(_mapper.Map<List<SongResponse>>(data));
        }

        [HttpPost]
        [Route(WebApiEndPoint.Song.CreateSong)]
        public async Task<IActionResult> CreateSong(SongRequest dataRequest)
        {
            var validate = this.CheckDataRequest(dataRequest);
            if (validate != null)
                return validate;

            var result = await _songService.AddObjectAsync(_mapper.Map<SongEntity>(dataRequest));
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
            var result = await _songService.UpdateObjectAsync(rowEntity);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.Song.DeleteSong)]
        public async Task<IActionResult> DeleteSong(string id)
        {
            var result = await _songService.DeleteObjectSync(id);
            if (result == null)
                return this.FailedActionDelete();
            return this.OkResponse<object>(_mapper.Map<SongResponse>(result));
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetTopSongListens)]
        public async Task<IActionResult> GetTopSongListens(int pageNumber = -1, int pageSize = -1)
        {
            var data = await _songService.GetTopListensSong(pageNumber, pageSize);
            var pagination = await _songService.GetPagination("", pageNumber, pageSize);
            return this.OkResponse<object>(_mapper.Map<List<SongResponse>>(data), pagination: pagination);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetTopSongDownloads)]
        public async Task<IActionResult> GetTopSongDownloads(int pageNumber = -1, int pageSize = -1)
        {
            var data = await _songService.GetTopDownloadsSong(pageNumber, pageSize);
            var pagination = await _songService.GetPagination("", pageNumber, pageSize);
            return this.OkResponse<object>(_mapper.Map<List<SongResponse>>(data), pagination: pagination);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetTopSongFavorites)]
        public async Task<IActionResult> GetTopSongFavorites(int pageNumber = -1, int pageSize = -1)
        {
            var data = await _songService.GetTopFavoritesSong(pageNumber, pageSize);
            var pagination = await _songService.GetPagination("", pageNumber, pageSize);
            return this.OkResponse<object>(_mapper.Map<List<SongResponse>>(data), pagination: pagination);
        }

        [HttpPut]
        [Route(WebApiEndPoint.Song.AddListensSong)]
        public async Task<IActionResult> AddListensSong(string songId)
        {
            var existedData = await _songService.GetSongById(songId);
            if (existedData == null)
            {
                return NotFound(new BadResult("Not found song"));
            }
            var data = await _songService.AddListensSong(songId);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(data));
        }

        [HttpPut]
        [Route(WebApiEndPoint.Song.AddDownloadsSong)]
        public async Task<IActionResult> AddDownloadsSong(string songId)
        {
            var existedData = await _songService.GetSongById(songId);
            if (existedData == null)
            {
                return NotFound(new BadResult("Not found song"));
            }
            var data = await _songService.AddDownloadsSong(songId);
            return this.OkResponse<object>(_mapper.Map<SongResponse>(data));
        }
    }
}
