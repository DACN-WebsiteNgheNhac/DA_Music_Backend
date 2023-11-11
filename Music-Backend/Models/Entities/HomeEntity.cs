namespace Music_Backend.Models.Entities
{
    public class HomeEntity
    {
        public string Id { get; set; }
        public string? TopicId { get; set; }
        public string? ArtistId { get; set; }
        public bool Active { get; set; }
    }
}
