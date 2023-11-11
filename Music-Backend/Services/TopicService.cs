using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public Task<TopicEntity?> AddObjectAsync(TopicEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<TopicEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TopicEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TopicEntity>> GetMultiObjectById(params object[] id)
        {
            return await _topicRepository.GetMultiObjectById(id);
        }

        public Task<TopicEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TopicEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<TopicEntity?> UpdateObjectAsync(TopicEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
