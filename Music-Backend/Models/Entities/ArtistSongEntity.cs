using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class ArtistSongEntity : EntityWithoutKey
    {
        [Required]
        [StringLength(36)]
        public string ArtistId { get; set; }

        [Required]
        [StringLength(36)]
        public string SongId { get; set; }

        [ForeignKey("ArtistId")]
        public ArtistEntity Artist { get; set; }

        [ForeignKey("SongId")]
        public SongEntity Song { get; set; }

    }
}
