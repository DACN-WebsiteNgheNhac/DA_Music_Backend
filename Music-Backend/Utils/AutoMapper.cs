using AutoMapper;
using Music_Backend.Models.Entities;
using Music_Backend.Models.RequestModels;
using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Utils
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
        }

        private void MapSong()
        {
            CreateMap<SongEntity, SongResponse>().ReverseMap();
            CreateMap<SongEntity, SongRequest>().ReverseMap();
        }
    }
}
