using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using static Music_Backend.Utils.Const.WebApiEndPoint;

namespace Music_Backend.Utils
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
            MapAlbum();
            MapArtist();
            MapTopic();

        }


        private void MapSong()
        {
            CreateMap<SongEntity, SongResponse>().ReverseMap();
            CreateMap<SongEntity, SongRequest>().ReverseMap();
        } 
        
        private void MapAlbum()
        {
            CreateMap<AlbumEntity, AlbumResponse>()
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.AlbumSongs.Select(albumSong => albumSong.Song).ToList()))
                .ReverseMap();
            CreateMap<AlbumEntity, AlbumRequest>().ReverseMap();
            //CreateMap<AlbumEntity, ICollection<SongResponse>>()
            //.ForMember(dest => dest, opt => opt.MapFrom(src => src.AlbumSongs.Select(albumSong => albumSong.Song).ToList()));
        }


        private void MapArtist()
        {
            CreateMap<ArtistEntity, ArtistResponse>().ReverseMap();
            CreateMap<ArtistEntity, ArtistRequest>().ReverseMap();
        }

        private void MapTopic()
        {
            //CreateMap<TopicEntity, TopicResponse>().ReverseMap();
            //CreateMap<TopicEntity, TopicRequest>().ReverseMap();
        }
    }
}
