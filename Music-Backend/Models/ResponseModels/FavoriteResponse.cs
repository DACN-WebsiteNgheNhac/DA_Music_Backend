namespace Music_Backend.Models.ResponseModels
{
    public class FavoriteResponse
    {
        public string SongId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset? CteatedAt { get; set; }
    }
}
