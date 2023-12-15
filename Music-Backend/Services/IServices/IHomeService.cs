using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Services.IServices
{
    public interface IHomeService
    {
        Task<List<object>> GetHome();
        Task<object> GetAudioUrlFromYoutube(string youtubeUrl);
    }
}
