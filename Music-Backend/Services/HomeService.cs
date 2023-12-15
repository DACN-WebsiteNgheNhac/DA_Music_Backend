using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;
using YoutubeExplode;
using YoutubeExplode.Common;
using static Music_Backend.Utils.Const.WebApiEndPoint;

namespace Music_Backend.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public HomeService(IHomeRepository homeRepository
            , IAlbumService albumService
            , ISongService songService
            , IArtistService artistService
            , ITopicService topicService
            , IMapper mapper)
        {
            _homeRepository = homeRepository;
            _albumService = albumService;
            _songService = songService;
            _artistService = artistService;
            _topicService = topicService;
            _mapper = mapper;
        }
        public async Task<List<object>> GetHome()
        {
            var homeRes = new List<object>();

            var home = await _homeRepository.GetHome();

            await AddTopArtists(homeRes);
            await AddRecommentAlbum(homeRes, home.TopicId);
            await AddNewReleaseSongs(homeRes);

            return homeRes;
        }

        public async Task<object> GetAudioUrlFromYoutube(string youtubeUrl)
        {
            var result = default(object);
            var song = new SongResponse();
            var youtube = new YoutubeClient();

            try
            {
                var video = await youtube.Videos.GetAsync(youtubeUrl);

                song.Name = video.Title;
                song.ArtistNames = video.Author.ChannelTitle;
                song.Image = GetImageYoutube(video.Thumbnails as Thumbnail[]);

                List<object> audioUrls = new List<object>();

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubeUrl);

                var streamInfo = streamManifest
                    .GetAudioStreams()
                    .Where(t => t.ToString() == "Audio-only (mp4)")
                    .OrderBy(t => t.Size)
                    .ToList();

                foreach (var item in streamInfo)
                {
                    audioUrls.Add(new
                    {
                        Size = item.Size.ToString(),
                        AudioUrl = item.Url
                    });
                }

                result = new
                {
                    AudioInformation = song,
                    AudioUrls = audioUrls
                };
            }
            catch { return null; }
            return result;
        }

        public string GetImageYoutube(Thumbnail[] thumbnails)
        {
            var imageUrl = "";
            if (thumbnails.Count() == 0)
                return imageUrl;
            if (thumbnails.Count() == 1)
                imageUrl = thumbnails[0].Url;
            thumbnails = thumbnails.OrderByDescending(t => t.Resolution.Width * t.Resolution.Height).ToArray();
            return thumbnails[thumbnails.Count() / 2].Url;
        }

        private async Task AddTopArtists(List<object> homeRes, int top = 5)
        {
            var hotArtists = new List<ArtistResponse>();
            int curPage = 1;
            int pageSize = 20;

            while(hotArtists.Count < top)
            {
                var songs = await _songService.GetAllObjectAsync(curPage, pageSize);

                if (songs.Count == 0)
                    break;

                foreach (var song in songs)
                {
                    foreach (var artist in song.ArtistSongs)
                    {
                        if(hotArtists.Where(t => t.Id == artist.ArtistId).FirstOrDefault() == null)
                        {
                            hotArtists.Add(_mapper.Map<ArtistResponse>(artist.Artist));
                            break;
                        }
                    }
                }

                curPage++;
            }

            var sectionTopArtists = new Item<List<ArtistResponse>>("artist", "hot-artist", "Những nghệ sỹ nổi bật");
            sectionTopArtists.Items = hotArtists;
            homeRes.Add(sectionTopArtists);
        }

        private async Task AddRecommentAlbum(List<object> homeRes, string topicId)
        {
            var topicIds = topicId.Split('-');
            var topics = await _topicService.GetMultiObjectById(topicIds);

           
            foreach (var topic in topics)
            {
                var sectionRecommentAlbum = new Item<List<AlbumResponse>>("album", "recomment-album", topic.Name);
                var albums = new List<AlbumResponse>();
                albums.AddRange(
                    _mapper.Map<List<AlbumResponse>>(await _albumService.SearchObjectByTopicIdAsync(topic.Id)));
                sectionRecommentAlbum.Items = albums;
                homeRes.Add(sectionRecommentAlbum);
            }
        }

        private async Task AddNewReleaseSongs(List<object> homeRes)
        {
            var newRelease = new NewReaseleItemResponse();

            var all = await _songService.GetSongsByArea("", 1, 20);
            newRelease.All.AddRange(_mapper.Map<List<SongResponse>>(all));

            var vPop = await _songService.GetSongsByArea("Vpop", 1, 20);
            newRelease.Vpop.AddRange(_mapper.Map<List<SongResponse>>(vPop));

            var otherPop = await _songService.GetSongsByArea("Other Pop", 1, 20);
            newRelease.Other.AddRange(_mapper.Map<List<SongResponse>>(otherPop));

            var sectionNewRelease = new Item<NewReaseleItemResponse>("song", "new-release", "Nhạc mới phát hành");
            sectionNewRelease.Items = newRelease;
            homeRes.Add(sectionNewRelease);
        }



    }

    public class NewReaseleItemResponse
    {
        public List<object> All { get; set; } = new List<object>();
        public List<object> Vpop { get; set; } = new List<object>();
        public List<object> Other { get; set; } = new List<object>();
    }
}
