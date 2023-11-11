using Microsoft.AspNetCore.Mvc;
using Music_Backend.Services.IServices;
using Music_Backend.Utils.Const;

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
    }
}
