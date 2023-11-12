using Music_Backend.Models.Entities;
using Music_Backend.Repositories;
using Music_Backend.Repositories.IRepositories;
using Music_Backend.Services.IServices;

namespace Music_Backend.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public async Task<PlaylistEntity?> AddObjectAsync(PlaylistEntity obj)
        {
            var prefix = "PL";
            var lastesObj = (await GetAllObjectAsync())
                .Where(t => t.Id.Contains(prefix))
                .OrderByDescending(t => t.Id)
                .FirstOrDefault();
            var id = "";
            if (lastesObj == null)
            {
                id = prefix + 1.ToString("000");
            }
            else
            {
                var split = lastesObj.Id.Split(prefix);
                
                if (split.Count() <= 0)
                {
                    id = Guid.NewGuid().ToString();
                }
                else
                {
                    var temp = int.Parse(split[1]);
                    id = prefix + (++temp).ToString("000");
                }
            }
            

            obj.Id = id;
            return await _playlistRepository.AddObjectAsync(obj);
        }

        public Task<PlaylistEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlaylistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _playlistRepository.GetAllObjectAsync(pageNumber, pageSize);
        }

        public Task<PlaylistEntity?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaylistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistEntity?> UpdateObjectAsync(PlaylistEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
