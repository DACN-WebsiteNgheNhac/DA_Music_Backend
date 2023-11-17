using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;
using Music_Backend.Utils;

namespace Music_Backend.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository
            , IArtistService artistService
            , IMapper mapper)
        {
            _albumRepository = albumRepository;
            _artistService = artistService;
            _mapper = mapper;
        }

        public Task<AlbumEntity?> AddObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetAlbumById(string id, int pageNumber = -1, int pageSize = -1)
        {
            var res = new List<object>();

            var album = await AddAlbumAsync(res, id);

            if (album == null)
                return null;

            var topicId = album?.Topic?.Id;
            var topicName = album?.Topic?.Name;

            var albumsByTopicIds = await AddRecommentAlbumAsync(res, id, topicId, topicName, pageSize, pageNumber);

            await AddRecommentArtistsAsync(res, albumsByTopicIds, topicName, pageNumber, pageSize);

            return res;
        }

        async Task AddRecommentArtistsAsync(List<object> res, List<AlbumEntity> albumsByTopicIds, string topicName
            , int pageNumber, int pageSize)
        {
            var sectionRecArtists = new Item<List<ArtistResponse>>("artist", "recomment-artist", "");
            var albumResponses = _mapper.Map<List<AlbumResponse>>(albumsByTopicIds);

            var songs = new List<SongEntity>();

            foreach (var albumsByTopicId in albumsByTopicIds)
            {
                songs.AddRange(albumsByTopicId.AlbumSongs.Select(t => t.Song));
            }


            var artistIds = new List<string>();
            foreach (var song in songs)
            {
                artistIds.AddRange(song.ArtistSongs.Select(t => t.ArtistId));
            }

            artistIds = artistIds.Distinct().ToList();

            artistIds = ObjectExtensions.ShuffleList(artistIds);

            if (pageNumber > -1 && pageSize > -1)
                artistIds = artistIds
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            var recArtists = _mapper.Map<List<ArtistResponse>>(await _artistService.GetArtistsById(artistIds.ToArray()));

            sectionRecArtists.Items = recArtists;

            res.Add(sectionRecArtists);
        }

        async Task<AlbumEntity> AddAlbumAsync(List<object> res, string id)
        {
            var album = await _albumRepository.GetObjectAsync(id);

            if (album == null)
            {
                return null;
            }

            var sectionAlbum = new Item<AlbumResponse>("album", "album-infor", album?.Topic?.Name);
            sectionAlbum.Items = _mapper.Map<AlbumResponse>(album);

            res.Add(sectionAlbum);

            return album;
        }

        async Task<List<AlbumEntity>> AddRecommentAlbumAsync(List<object> res, string albumId, string topicId, string topicName
            , int pageNumber, int pageSize)
        {
            var sectionRecAlbums = new Item<List<AlbumResponse>>("album", "recomment-album", topicName);
            var albumsByTopicIds = await _albumRepository.SearchObjectByTopicIdAsync(topicId, -1, -1);
            albumsByTopicIds = albumsByTopicIds.Where(t => t.Id != albumId).ToList();

            albumsByTopicIds = ObjectExtensions.ShuffleList(albumsByTopicIds);

            sectionRecAlbums.Items = _mapper.Map<List<AlbumResponse>>(albumsByTopicIds);
            if (pageNumber > -1 && pageSize > -1)
                albumsByTopicIds = albumsByTopicIds
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            res.Add(sectionRecAlbums);

            return albumsByTopicIds;
        }

        public Task<List<AlbumEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumEntity?> GetObjectAsync(params object[] id)
        {
            return await _albumRepository.GetObjectAsync(id);
        }

        public Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination?> GetPaginationByTopicId(string topicId, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _albumRepository.GetCountByTopicIdAsync(topicId);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<AlbumEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _albumRepository.SearchObjectAsync(query, pageNumber, pageSize);
        }

        public async Task<List<AlbumEntity>> SearchObjectByTopicIdAsync(string topicId, int pageNumber = -1, int pageSize = -1)
        {
            return await _albumRepository.SearchObjectByTopicIdAsync(topicId, pageNumber, pageSize);
        }

        public Task<AlbumEntity?> UpdateObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
