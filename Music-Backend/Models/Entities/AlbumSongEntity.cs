using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class AlbumSongEntity : EntityWithoutKey
    {
        [Required]
        [StringLength(36)]
        public string AlbumId { get; set; }

        [Required]
        [StringLength(36)]
        public string SongId { get; set; }

        [ForeignKey("AlbumId")]
        public AlbumEntity Album { get; set; }

        [ForeignKey("SongId")]
        public SongEntity Song { get; set; }

    }
}
