using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IArtistRepository : IRepository<ArtistEntity, ArtistEntity>
    {
        public Task<int> GetCountAsync(string query);
        public Task<List<ArtistEntity>> GetTopArtistsAsync(int top);

        public Task<List<ArtistEntity>> GetArtistsById(string[] ids);
    }
}
