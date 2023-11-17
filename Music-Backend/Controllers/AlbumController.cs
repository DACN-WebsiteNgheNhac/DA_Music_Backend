using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService
            , IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndPoint.Album.GetAlbumsByTopicId)]
        public async Task<IActionResult> GetAlbumsByTopicIdAsync(string? topicId, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _albumService.SearchObjectByTopicIdAsync(topicId, pageNumber, pageSize);
            //var songs = _mapper.Map<ICollection<SongResponse>>(data);
            var pagination = await _albumService.GetPaginationByTopicId(topicId, pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<AlbumResponse>>(data)
                , pagination: pagination);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Album.GetAlbumById)]
        public async Task<IActionResult> GetAlbumsByIdAsync(string albumId, int pageNumber = -1, int pageSize = -1)
        {
            //var data = await _albumService.GetObjectAsync(albumId);
            var data = await _albumService.GetAlbumById(albumId, pageNumber, pageSize);
            return this.OkResponse<object>(data);
        }


    }
}
