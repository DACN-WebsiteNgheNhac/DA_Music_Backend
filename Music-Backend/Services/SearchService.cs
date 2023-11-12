using AutoMapper;
using Music_Backend.Controllers;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public SearchService(IAlbumService albumService
            , ISongService songService
            , IArtistService artistService
            , IMapper mapper)
        {
            _albumService = albumService;
            _songService = songService;
            _artistService = artistService;
            _mapper = mapper;
        }

        public async Task<List<object>> SearchObjectsAsync(TypeSearch type, string query, int pageNumber = -1, int pageSize = -1)
        {
            var res = new List<object>();
            switch (type) 
            { 
                case TypeSearch.Song:
                    await AddSearchSongsAsync(res, query, pageNumber, pageSize);
                    break;
                case TypeSearch.Album:
                    await AddSearchAlbumsAsync(res, query, pageNumber, pageSize);
                    break;
                case TypeSearch.Artist:
                    await AddSearchArtistsAsync(res, query, pageNumber, pageSize);
                    break;
                default:
                {
                    await AddSearchSongsAsync(res, query, pageNumber, pageSize);
                    await AddSearchAlbumsAsync(res, query, pageNumber, pageSize);
                    await AddSearchArtistsAsync(res, query, pageNumber, pageSize);
                    break;
                }
            }
            return res;
        }

        public async Task AddSearchSongsAsync(List<object> res, string query, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _songService.SearchObjectAsync(query, pageNumber, pageSize);
            var sectionSearch = new Item<List<SongResponse>>("song", "search-song", "");
            sectionSearch.Items = _mapper.Map<List<SongResponse>>(data);
            res.Add(sectionSearch);
        }

        public async Task AddSearchAlbumsAsync(List<object> res, string query, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _albumService.SearchObjectAsync(query, pageNumber, pageSize);
            var sectionSearch = new Item<List<AlbumResponse>>("album", "search-album", "");
            sectionSearch.Items = _mapper.Map<List<AlbumResponse>>(data);
            res.Add(sectionSearch);
        }

        public async Task AddSearchArtistsAsync(List<object> res, string query, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _artistService.SearchObjectAsync(query, pageNumber, pageSize);
            var sectionSearch = new Item<List<ArtistResponse>>("artist", "search-artist", "");
            sectionSearch.Items = _mapper.Map<List<ArtistResponse>>(data);
            res.Add(sectionSearch);
        }

    }
}
