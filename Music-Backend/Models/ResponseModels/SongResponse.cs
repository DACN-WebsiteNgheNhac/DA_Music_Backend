using Music_Backend.Models.Entities;

namespace Music_Backend.Models.ResponseModels
{
    public class SongResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? SongUrl { get; set; }
        public double? SongTime { get; set; }
        public double? Listens { get; set; }

        //public ICollection<PlaylistSongEntity> PlaylistSongs { get; set; }
        //public ICollection<FavoriteEntity> Favorites { get; set; }
        //public ICollection<AlbumSongEntity> AlbumSongs { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public string? Tag { get; set; }
        public string? ArtistNames { get; set; }
        public ICollection<CommentResponse> Comments { get; set; }
    }
}
