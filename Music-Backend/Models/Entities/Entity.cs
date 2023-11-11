using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.Entities
{
    public class Entity : EntityWithoutKey
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }
    }

    public class EntityWithoutKey
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
