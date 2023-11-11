using Music_Backend.Models.Entities;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface ITopicService : IService<TopicEntity>
    {
        Task<List<TopicEntity>> GetMultiObjectById(params object[] id);

    }
}
