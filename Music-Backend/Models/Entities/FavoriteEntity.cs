using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class FavoriteEntity : EntityWithoutKey
    {
        [Required]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        [StringLength(36)]
        public string SongId { get; set; }

        [ForeignKey("SongId")]
        public SongEntity Song { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
