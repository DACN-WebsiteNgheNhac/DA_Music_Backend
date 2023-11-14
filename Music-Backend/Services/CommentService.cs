using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentEntity?> AddObjectAsync(CommentEntity obj)
        {
            obj.Id = Guid.NewGuid().ToString();
            obj.CreatedAt = DateTimeOffset.Now;
            return await _commentRepository.AddObjectAsync(obj);
        }

        public Task<CommentEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<CommentEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination> GetPagination(string songId, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize < 0)
                return null;
            var totalPage = await _commentRepository.GetCountAsync(songId);
            totalPage = (int)Math.Ceiling((totalPage / (pageSize * 1.0)));
            return new Pagination(pageNumber, totalPage, pageSize);
        }

        public Task<List<CommentEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            return _commentRepository.SearchObjectAsync(query, pageNumber, pageSize);   
        }

        public Task<CommentEntity?> UpdateObjectAsync(CommentEntity obj)
        {
            obj.UpdatedAt = DateTimeOffset.Now;
            return _commentRepository.UpdateObjectAsync(obj);
        }
    }
}
