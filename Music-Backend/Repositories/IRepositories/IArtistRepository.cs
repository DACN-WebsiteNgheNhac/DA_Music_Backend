using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IArtistRepository : IRepository<ArtistEntity, ArtistEntity>
    {
        public Task<int> GetCountAsync(string query);
    }
}
