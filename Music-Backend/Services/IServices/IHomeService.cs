using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Services.IServices
{
    public interface IHomeService
    {
        Task<SectionResponse> GetHome();
    }
}
