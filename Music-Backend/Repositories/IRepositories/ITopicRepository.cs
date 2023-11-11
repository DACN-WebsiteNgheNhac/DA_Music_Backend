using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface ITopicRepository : IRepository<TopicEntity, TopicEntity>
    {
        Task<List<TopicEntity>> GetMultiObjectById(params object[] id);
    }
}
