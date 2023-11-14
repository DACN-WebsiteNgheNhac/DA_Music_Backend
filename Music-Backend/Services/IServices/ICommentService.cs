using Music_Backend.Models.Entities;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IService;

namespace Music_Backend.Services.IServices
{
    public interface ICommentService : IService<CommentEntity>
    {
        Task<Pagination> GetPagination(string songId, int pageNumber, int pageSize);
    }
}
