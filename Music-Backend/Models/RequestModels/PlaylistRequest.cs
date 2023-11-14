namespace Music_Backend.Models.RequestModels
{
    public class PlaylistRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
    }
}
