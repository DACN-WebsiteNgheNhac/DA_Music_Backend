using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity, UserEntity>
    {
        Task<UserEntity> LoginAsync(string username, string password);
    }
}
