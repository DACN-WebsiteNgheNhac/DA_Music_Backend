using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;
using static Music_Backend.Utils.Const.WebApiEndPoint;

namespace Music_Backend.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public HomeService(IHomeRepository homeRepository
            , IAlbumService albumService
            , ISongService songService
            , ITopicService topicService
            , IMapper mapper)
        {
            _homeRepository = homeRepository;
            _albumService = albumService;
            _songService = songService;
            _topicService = topicService;
            _mapper = mapper;
        }
        public async Task<SectionResponse> GetHome()
        {
            var homeRes = new SectionResponse();
            homeRes.Sections = new List<object>();

            var home = await _homeRepository.GetHome();

            await AddRecommentAlbum(homeRes, home.TopicId);
            await AddNewRealseSongs(homeRes);


            return homeRes;
        }

        private async Task AddRecommentAlbum(SectionResponse homeRes, string topicId)
        {
            var topicIds = topicId.Split('-');
            var topics = await _topicService.GetMultiObjectById(topicIds);

            foreach (var topic in topics)
            {
                var sectionRecommentAlbum = new Item<AlbumResponse>("album", "recomment-album", topic.Name);
                sectionRecommentAlbum.Items.AddRange(
                    _mapper.Map<List<AlbumResponse>>(await _albumService.SearchObjectByTopicIdAsync(topic.Id)));
                homeRes.Sections.Add(sectionRecommentAlbum);
            }
        }

        private async Task AddNewRealseSongs(SectionResponse homeRes)
        {
            var sectionNewRealseVpopSong = new Item<SongResponse>("song", "new-realse", "Vpop");
            var vPop = await _songService.GetSongsByArea("Vpop", 1, 20);
            sectionNewRealseVpopSong.Items.AddRange(
                _mapper.Map<List<SongResponse>>(vPop));

            var sectionNewRealseAnotherPopSong = new Item<SongResponse>("song", "new-realse", "Another pop");
            var anotherPop = await _songService.GetSongsByArea("Another Pop", 1, 20);
            sectionNewRealseAnotherPopSong.Items.AddRange(
                _mapper.Map<List<SongResponse>>(anotherPop));

           
            homeRes.Sections.Add(sectionNewRealseVpopSong);
            homeRes.Sections.Add(sectionNewRealseAnotherPopSong);
        }

    }
}
