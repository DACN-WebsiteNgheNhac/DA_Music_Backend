namespace Music_Backend.Models.ResponseModels
{
    public class CommentResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SongId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public string Username { get; set; }
        public string ImageUser { get; set; }

    }
}
