using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Search comment by songId
        /// </summary>
        /// <param name="songId"> Input songId to search </param>
        /// <param name="pageNumber">Page number need go to</param>
        /// <param name="pageSize">Total entry in each page</param>
        [HttpGet]
        [Route(WebApiEndPoint.Comment.GetCommentsBySongId)]
        public async Task<IActionResult> GetCommentsBySongId(string songId, int pageNumber = -1, int pageSize = -1)
        {
            var data = await _commentService.SearchObjectAsync(songId, pageNumber, pageSize);
            var pagination = await _commentService.GetPagination(songId, pageNumber, pageSize);
            return this.OkResponse<object>(
                _mapper.Map<List<CommentResponse>>(data)
                , pagination: pagination);
        }
    }
}
