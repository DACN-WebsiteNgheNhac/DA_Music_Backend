using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class UserPlaylistRepository : BaseRepository<UserPlaylistEntity>, IUserPlaylistRepository
    {
        public async Task<UserPlaylistEntity?> AddObjectAsync(UserPlaylistEntity obj)
        {
            return await AddAsync(obj);
        }

        public Task<UserPlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPlaylistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserPlaylistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<UserPlaylistEntity?> UpdateObjectAsync(UserPlaylistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
