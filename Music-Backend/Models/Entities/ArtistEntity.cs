using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.Entities
{
    public class ArtistEntity : Entity
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ArtistName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public DateTimeOffset? DebutDate { get; set; }
        public string? Description { get; set; }

        [StringLength(200)]
        public string? Image { get; set; }
        public string? National { get; set; }
        public string? Tag { get; set; }

        public ICollection<ArtistMusicVideoEntity> ArtistMusicVideos { get; set; }
        public ICollection<ArtistSongEntity> ArtistSongs { get; set; }
    }
}
