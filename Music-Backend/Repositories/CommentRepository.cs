using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public async Task<CommentEntity?> AddObjectAsync(CommentEntity obj)
        {
            return await AddAsync(obj);
        }

        public Task<CommentEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountAsync(string query)
        {
            return await GetAllAsync().Result.Where(t => t.UserId == query).CountAsync();
        }

        public Task<CommentEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<CommentEntity, bool>> predicate =
              t => t.SongId.Contains(query)
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.AsNoTracking()
                    .Where(predicate)
                    .OrderByDescending(t => t.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .Include(t => t.User)
                    .ToListAsync();
            else
                return await GetAllAsync().Result.AsNoTracking()
                    .Where(predicate)
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.User)
                    .ToListAsync();
        }

        public async Task<CommentEntity?> UpdateObjectAsync(CommentEntity obj)
        {
            return await UpdateAsync(obj);
        }
    }
}
