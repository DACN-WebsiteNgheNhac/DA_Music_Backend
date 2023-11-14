using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;
using System.Collections.Generic;

namespace Music_Backend.Utils
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
            MapAlbum();
            MapArtist();
            MapPlaylist();
            MapPlaylistSong();
            MapUserPlaylist();
            MapFavorite();
            MapComment();
            MapTopic();

        }

        private void MapFavorite()
        {
            CreateMap<FavoriteEntity, FavoriteResponse>().ReverseMap();
            //CreateMap<FavoriteEntity, FavoriteRequest>().ReverseMap();
        }

        private void MapComment()
        {
            CreateMap<CommentEntity, CommentResponse>().ReverseMap();
            CreateMap<CommentEntity, CommentRequest>().ReverseMap();
        }

        private void MapUserPlaylist()
        {
            //CreateMap<UserPlaylistEntity, UserPlaylistResponse>().ReverseMap();
            //CreateMap<UserPlaylistEntity, UserPlaylistRequest>().ReverseMap();
        }

        private void MapSong()
        {
            CreateMap<SongEntity, SongResponse>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Select(cmt => cmt).ToList()))
                .ForMember(dest => dest.ArtistNames, opt => opt.MapFrom(src => string.Join(" - ", src.ArtistSongs.Select(cmt => cmt.Artist.ArtistName))))
                .ReverseMap();
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

        private void MapPlaylistSong()
        {
            CreateMap<PlaylistSongEntity, PlaylistSongResponse>().ReverseMap();
            CreateMap<PlaylistSongEntity, PlaylistSongRequest>().ReverseMap();
        }

        private void MapPlaylist()
        {
            CreateMap<PlaylistEntity, PlaylistResponse>()
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.PlaylistSongs.Select(playlistSong => playlistSong.Song).ToList()))
                .ReverseMap();
            CreateMap<PlaylistEntity, PlaylistRequest>().ReverseMap();
        }

        private void MapTopic()
        {
            //CreateMap<TopicEntity, TopicResponse>().ReverseMap();
            //CreateMap<TopicEntity, TopicRequest>().ReverseMap();
        }
    }
}
