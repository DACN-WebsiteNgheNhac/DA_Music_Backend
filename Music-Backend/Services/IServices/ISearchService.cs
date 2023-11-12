using Music_Backend.Controllers;
using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Services.IServices
{
    public interface ISearchService
    {
        public Task<List<object>> SearchObjectsAsync(TypeSearch type, string query, int pageNumber = -1, int pageSize = -1);
    }
}
