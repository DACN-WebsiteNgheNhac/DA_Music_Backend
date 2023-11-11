using Music_Backend.Models.Entities;
namespace Music_Backend.Repositories.IRepositories
{
    public interface IHomeRepository
    {
        Task<HomeEntity> GetHome();
    }
}
