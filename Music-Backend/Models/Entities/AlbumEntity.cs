namespace Music_Backend.Models.Entities
{
    public class AlbumEntity : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
        public ICollection<AlbumSongEntity> AlbumSongs { get; set; }
    }
}
