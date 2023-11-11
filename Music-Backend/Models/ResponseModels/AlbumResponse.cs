using Music_Backend.Models.Entities;

namespace Music_Backend.Models.ResponseModels
{
    public class AlbumResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
        public ICollection<SongResponse> Songs { get; set; }
    }
}
