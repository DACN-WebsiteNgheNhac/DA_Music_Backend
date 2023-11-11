using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IAlbumRepository : IRepository<AlbumEntity, AlbumEntity>
    {
        public Task<int> GetCountByTopicIdAsync(string topicId);
        public Task<List<AlbumEntity>> SearchObjectByTopicIdAsync(string topicId, int pageNumber = -1, int pageSize = -1);
    }
}
