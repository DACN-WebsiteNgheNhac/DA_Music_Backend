using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class CommentEntity : Entity
    {
        [StringLength(36)]
        public string UserId { get; set; }

        [StringLength(36)]
        public string SongId { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(SongId))]
        public SongEntity Song { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }


    }
}
