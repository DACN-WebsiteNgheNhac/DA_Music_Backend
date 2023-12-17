using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface ISongService : IService<SongEntity>
    {
        Task<Pagination?> GetPagination(string query, int pageNumber, int pageSize);

        Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize);
        Task<List<SongEntity>> GetSongsByArtistId(string artistId);
        Task<SongEntity> GetSongById(string songId);

        Task<List<SongEntity>> GetTopListensSong(int pageNumber = -1, int pageSize = -1);
        Task<List<SongEntity>> GetTopDownloadsSong(int pageNumber = -1, int pageSize = -1);   
        Task<List<SongEntity>> GetTopFavoritesSong(int pageNumber = -1, int pageSize = -1);   
        Task<SongEntity> AddListensSong(string songId);
        Task<SongEntity> AddDownloadsSong(string songId);

    }
}
