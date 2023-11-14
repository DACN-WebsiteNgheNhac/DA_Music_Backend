using Music_Backend.Models.Entities;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class UserPlaylistService : IUserPlaylistService
    {
        private readonly IUserPlaylistRepository _userPlaylistRepository;

        public UserPlaylistService(IUserPlaylistRepository userPlaylistRepository)
        {
            _userPlaylistRepository = userPlaylistRepository;
        }
        public Task<UserPlaylistEntity?> AddObjectAsync(UserPlaylistEntity obj)
        {
            return _userPlaylistRepository.AddObjectAsync(obj);
        }

        public Task<UserPlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPlaylistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<UserPlaylistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<UserPlaylistEntity?> UpdateObjectAsync(UserPlaylistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
