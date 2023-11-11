namespace Music_Backend.Models.Entities
{
    public class PlaylistEntity : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
        public ICollection<UserPlaylistEntity> UserPlaylists { get; set; }
        public ICollection<PlaylistSongEntity> PlaylistSongs { get; set; }
        
    }
}
