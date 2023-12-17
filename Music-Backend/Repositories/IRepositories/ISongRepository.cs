using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface ISongRepository : IRepository<SongEntity, SongEntity>
    {
        Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize);
        Task<List<SongEntity>> GetSongsByArtistId(string artistId);
        Task<List<SongEntity>> GetTopListensSong(int pageNumber = -1, int pageSize = -1);
        Task<List<SongEntity>> GetTopDownloadsSong(int pageNumber = -1, int pageSize = -1);
        Task<List<SongEntity>> GetTopFavoritesSong(int pageNumber = -1, int pageSize = -1);
        Task<SongEntity> AddListensSong(string songId);
        Task<SongEntity> AddDownloadsSong(string songId);
        Task<SongEntity?> GetObjectAsync(bool includeComment, params object[] id);
    }
}
