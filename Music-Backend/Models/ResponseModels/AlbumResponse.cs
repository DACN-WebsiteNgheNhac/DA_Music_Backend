namespace Music_Backend.Models.ResponseModels
{
    public class AlbumResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
