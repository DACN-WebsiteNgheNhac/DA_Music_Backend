using Microsoft.AspNetCore.Mvc;
using Music_Backend.Services;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{

    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        /// <summary>
        /// Search 
        /// </summary>
        /// <param name="type">Value include: 0 - Multi search; 1 - Search songs; 2 - Search albums;  3 - Search artists</param>
        /// <param name="query"></param>
        /// <param name="pageNumber">Page number need go to</param>
        /// <param name="pageSize">Total entry in each page</param>
        [HttpGet]
        [Route(WebApiEndPoint.Search.SearchData)]
        public async Task<IActionResult> SearchAsync(TypeSearch type, string? query, int pageNumber = -1, int pageSize = -1)
        {
            var homeRes = await _searchService.SearchObjectsAsync(type, query, pageNumber, pageSize);   
            return this.OkResponse<object>(homeRes);
        }

    }

    public enum TypeSearch
    {
        Multi,
        Song,
        Album,
        Artist
    }
}
