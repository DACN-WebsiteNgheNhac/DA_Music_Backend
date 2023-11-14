using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface ICommentRepository : IRepository<CommentEntity, CommentEntity>
    {
        public Task<int> GetCountAsync(string query);
    }
}
