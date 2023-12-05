using System.ComponentModel;

namespace Music_Backend.Models.Entities
{
    public class SongEntity : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? SongUrl { get; set; }
        public double? SongTime { get; set; }
        public string? Tag { get; set; }

        [DefaultValue("Vpop")]
        public string? Area { get; set; }

        [DefaultValue(0)]
        public double Listens { get; set; }

        [DefaultValue(0)]
        public double Downloads { get; set; }
        public ICollection<PlaylistSongEntity> PlaylistSongs { get; set; }
        public ICollection<FavoriteEntity> Favorites { get; set; }
        public ICollection<AlbumSongEntity> AlbumSongs { get; set; }
        public ICollection<ArtistSongEntity> ArtistSongs { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }

        public SongEntity()
        {
            
        }
        public SongEntity(SongEntity t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            Image = t.Image;
            SongUrl = t.SongUrl;
            SongTime = t.SongTime;
            Tag = t.Tag;
            Area = t.Area;
            Listens = t.Listens;
            CreatedAt = t.CreatedAt;
        }

    }
}
