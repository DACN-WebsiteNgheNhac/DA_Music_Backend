using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class ArtistMusicVideoEntity
    {
        [Required]
        [StringLength(36)]
        public string ArtistId { get; set; }

        [Required]
        [StringLength(36)]
        public string MusicVideoId { get; set; }

        [ForeignKey("ArtistId")]
        public ArtistEntity Artist { get; set; }

        [ForeignKey("MusicVideoId")]
        public MusicVideoEntity MusicVideo { get; set; }
    }
}
