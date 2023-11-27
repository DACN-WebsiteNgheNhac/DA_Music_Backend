using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

     
        [HttpGet]
        [Route(WebApiEndPoint.Artist.GetArtistById)]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var data = await _artistService.GetArtist(id);
            if (data == null)
            {
                return NotFound(new BadResult("Not found artist"));
            }
            return this.OkResponse<object>(data);
        }
    }
}
