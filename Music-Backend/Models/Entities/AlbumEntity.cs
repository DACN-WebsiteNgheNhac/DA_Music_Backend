using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class AlbumEntity : Entity
    {
        public string Name { get; set; }

        [StringLength(36)]
        public string? TopicId { get; set; }

        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }

        [ForeignKey("TopicId")]
        public TopicEntity Topic { get; set; }
        public ICollection<AlbumSongEntity> AlbumSongs { get; set; }
    }
}
