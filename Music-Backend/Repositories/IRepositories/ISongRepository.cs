using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface ISongRepository : IRepository<SongEntity, SongEntity>
    {
        Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize);
        Task<List<SongEntity>> GetSongsByArtistId(string artistId);
    }
}
