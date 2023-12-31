﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService
            , IArtistService artistService
            , IMapper mapper)
        {
            _albumService = albumService;
            _artistService = artistService;
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
        public async Task<IActionResult> GetAlbumsByIdAsync(string albumId)
        {
            var data = await _albumService.GetAlbumById(albumId);
            return this.OkResponse<AlbumResponse>(_mapper.Map<AlbumResponse>(data));
        }

        [HttpGet]
        [Route(WebApiEndPoint.Album.GetSuggestionAlbumById)]
        public async Task<IActionResult> GetSuggestionAlbumsByIdAsync(string albumId, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _albumService.GetSuggestionAlbumById(albumId, pageNumber, pageSize);
            return this.OkResponse<object>(data);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Album.GetAlbumsByArtistId)]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string artistId)
        {
            var existedArtist = await _artistService.GetArtistsById(new string[] { artistId });
            if (existedArtist == null ||existedArtist.Count == 0)
            {
                return NotFound(new BadResult("Not found artist"));
            }

            var data = await _albumService.GetAlbumsByArtistIdAsync(artistId);
            return this.OkResponse<object>(_mapper.Map<List<AlbumResponse>>(data));
        }

    }
}
