using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;

namespace Music_Backend.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public async Task<UserEntity?> AddObjectAsync(UserEntity obj)
        {
            return await AddAsync(obj);
        }

        public Task<UserEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await GetAllAsync().Result.ToListAsync();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity?> GetObjectAsync(params object[] id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<UserEntity> LoginAsync(string username, string password)
        {
            return await 
                _context.User.AsNoTracking()
                .Where(t => t.Username == username && t.Password == password)
                .Include(t => t.Role).AsNoTracking()
                .FirstOrDefaultAsync();
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
