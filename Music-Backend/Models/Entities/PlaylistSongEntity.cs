using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class PlaylistSongEntity : EntityWithoutKey
    {
        [Required]
        [StringLength(36)]
        public string PlaylistId { get; set; }

        [Required]
        [StringLength(36)]
        public string SongId { get; set; }

        [ForeignKey("PlaylistId")]
        public PlaylistEntity Playlist { get; set; }

        [ForeignKey("SongId")]
        public SongEntity Song { get; set; }

    }
}
