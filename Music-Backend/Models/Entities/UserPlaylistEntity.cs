using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.Entities
{
    public class UserPlaylistEntity
    {
        [Required]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        [StringLength(36)]
        public string PlaylistId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [ForeignKey("PlaylistId")]
        public PlaylistEntity Playlist { get; set; }
    }
}
