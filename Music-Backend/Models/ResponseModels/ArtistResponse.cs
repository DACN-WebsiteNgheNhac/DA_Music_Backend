using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.ResponseModels
{
    public class ArtistResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public DateTimeOffset? DebutDate { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? National { get; set; }
        public string? Tag { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
