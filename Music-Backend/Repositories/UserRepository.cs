using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public Task<UserEntity?> AddObjectAsync(UserEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity?> GetObjectAsync(params object[] id)
        {
            return await GetByIdAsync(id);
        }

        public Task<List<UserEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> UpdateObjectAsync(UserEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
