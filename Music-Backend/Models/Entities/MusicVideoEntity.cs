namespace Music_Backend.Models.Entities
{
    public class MusicVideoEntity : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? VideoUrl { get; set; }
        public double? VideoTime { get; set; }

        public ICollection<ArtistMusicVideoEntity> ArtistMusicVideos { get; set; }
    }
}
