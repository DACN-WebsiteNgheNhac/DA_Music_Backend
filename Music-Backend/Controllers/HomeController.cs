using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;
using YoutubeExplode;
 
using YoutubeExplode.Videos.Streams;

namespace Music_Backend.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        [Route(WebApiEndPoint.Home.GetHome)]
        public async Task<IActionResult> GetHomeAsync()
        {
            var homeRes = await _homeService.GetHome();
            return this.OkResponse<object>(homeRes);
        }

        [HttpGet]
        [Route(WebApiEndPoint.Home.GetAudioUrlFromYoutube)]
        public async Task<IActionResult> GetAudioUrlFromYoutubeAsync(string url)
        {
            var result = await _homeService.GetAudioUrlFromYoutube(url);
            if (result == null)
            {
                return NotFound(new BadResult("Not found or invalid format url"));
            }
            return this.OkResponse<object>(result);
        }
    }
}
