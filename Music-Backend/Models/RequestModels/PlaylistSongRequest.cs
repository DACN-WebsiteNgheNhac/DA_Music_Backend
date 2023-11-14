using System.ComponentModel.DataAnnotations;

namespace Music_Backend.Models.RequestModels
{
    public class PlaylistSongRequest
    {
        public string? PlaylistId { get; set; }
        public string SongId { get; set; }
    }
}
