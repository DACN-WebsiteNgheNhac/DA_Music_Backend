using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISongRepository _songRepository;

        public ArtistService(IArtistRepository artistRepository,
            IAlbumRepository albumRepository,
            ISongRepository songRepository
            )
        {
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
        }
        public Task<ArtistEntity?> AddObjectAsync(ArtistEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArtistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetArtist(string id)
        {
            var res = new List<object>();

            var inforArtist = (await _artistRepository.GetArtistsById(new string[] { id })).FirstOrDefault();

            if (inforArtist == null)
                return null;

            var albumsByArtistId = await _albumRepository.GetAlbumsByArtistIdAsync(id);
            albumsByArtistId.ForEach(t => t.AlbumSongs.Clear());

            var songsByArtistId = await _songRepository.GetSongsByArtistId(id);
            songsByArtistId.ForEach(t => t.ArtistSongs.Clear());

            var sectionInforArtist = new Item<object>("artist", "artist", "");
            sectionInforArtist.Items = inforArtist;
            res.Add(sectionInforArtist);

            var sectionAlbumsByArtistId = new Item<object>("album", "album", "");
            sectionAlbumsByArtistId.Items = albumsByArtistId;
            res.Add(sectionAlbumsByArtistId);

            var sectionSongsByArtistId = new Item<object>("song", "song", "");
            sectionSongsByArtistId.Items = songsByArtistId;
            res.Add(sectionSongsByArtistId);

            return res;
        }

        public async Task<List<ArtistEntity>> GetArtistsById(string[] ids)
        {
            return await _artistRepository.GetArtistsById(ids);
        }

        public Task<ArtistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _artistRepository.GetCountAsync(query);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public async Task<List<ArtistEntity>> GetTopArtistsAsync(int top = 5)
        {
            return await _artistRepository.GetTopArtistsAsync(top);
        }

        public async Task<List<ArtistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return await _artistRepository.SearchObjectAsync(query, pageNumber, pageSize);
        }

        public Task<ArtistEntity?> UpdateObjectAsync(ArtistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
