using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class TopicRepository : BaseRepository<TopicEntity>, ITopicRepository
    {
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

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TopicEntity>> GetMultiObjectById(params object[] id)
        {
            return await GetAllAsync().Result.Where(t => id.Contains(t.Id)).ToListAsync();
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
