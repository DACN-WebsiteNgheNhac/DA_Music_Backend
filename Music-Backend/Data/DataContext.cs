using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;

namespace Music_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<FavoriteEntity> Favorite { get; set; }
        public DbSet<UserPlaylistEntity> UserPlaylist { get; set; }
        public DbSet<PlaylistEntity> Playlist { get; set; }
        public DbSet<PlaylistSongEntity> PlaylistSong { get; set; }
        public DbSet<SongEntity> Song { get; set; }
        public DbSet<ArtistEntity> Artist { get; set; }
        public DbSet<ArtistSongEntity> ArtistSong { get; set; }
        public DbSet<ArtistMusicVideoEntity> ArtistMusicVideo { get; set; }
        public DbSet<MusicVideoEntity> MusicVideo { get; set; }
        public DbSet<AlbumEntity> Album { get; set; }
        public DbSet<AlbumSongEntity> AlbumSong { get; set; }
        public DbSet<HomeEntity> Home { get; set; }
        public DbSet<TopicEntity> Topic { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddPrimaryKeys(modelBuilder);
        }

        private void AddPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteEntity>()
               .HasKey(pk => new { pk.SongId, pk.UserId });  
            
            modelBuilder.Entity<UserPlaylistEntity>()
               .HasKey(pk => new { pk.UserId, pk.PlaylistId });

            modelBuilder.Entity<PlaylistSongEntity>()
               .HasKey(pk => new { pk.PlaylistId, pk.SongId });

            modelBuilder.Entity<ArtistSongEntity>()
               .HasKey(pk => new { pk.ArtistId, pk.SongId });

            modelBuilder.Entity<ArtistMusicVideoEntity>()
               .HasKey(pk => new { pk.ArtistId, pk.MusicVideoId });

            modelBuilder.Entity<AlbumSongEntity>()
               .HasKey(pk => new { pk.AlbumId, pk.SongId });

        }
    }
}