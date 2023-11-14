using Music_Backend.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.RequestModels
{
    public class CommentRequest
    {
        [Required]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        [StringLength(36)]
        public string SongId { get; set; }

        public string Content { get; set; }
    }
}
