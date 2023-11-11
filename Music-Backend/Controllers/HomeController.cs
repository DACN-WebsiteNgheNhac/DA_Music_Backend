using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;
using Music_Backend.Utils.Const;

namespace Music_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        public HomeController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongsAsync(int pageNumber = -1, int pageSize = -1)
        {
            var homeRes = new HomeResponse();
            homeRes.Sections = new List<object>();

            var sectionSong = new Item<SongResponse>("song", "playlist");
            sectionSong.Items.Add(new SongResponse());
            sectionSong.Items.Add(new SongResponse());

            var sectionAlbum = new Item<AlbumResponse>("album", "recomment-album");
            sectionAlbum.Items.Add(new AlbumResponse());
            sectionAlbum.Items.Add(new AlbumResponse());

            homeRes.Sections.Add(sectionSong);
            homeRes.Sections.Add(sectionAlbum);
            return this.OkResponse<object>(
                homeRes
                , pagination: null);
            //var data = await _SongService.GetAllObjectAsync(pageNumber, pageSize);
            //var pagination = await _SongService.GetPagination("", pageNumber, pageSize);
            //return this.OkResponse<object>(
            //    _mapper.Map<List<SongResponse>>(data)
            //    , pagination: pagination);
        }
    }
}
