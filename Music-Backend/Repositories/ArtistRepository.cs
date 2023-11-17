using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class ArtistRepository : BaseRepository<ArtistEntity>, IArtistRepository
    {
        public async Task<ArtistEntity?> AddObjectAsync(ArtistEntity obj)
        {
            if (string.IsNullOrEmpty(obj.Image))
            {
                obj.Image = "https://res.cloudinary.com/thanhle/image/upload/v1697893739/NStore/DefaultIcon/ArtistMale_npqi8v.jpg";
            }
            obj.Id = Guid.NewGuid().ToString();
            obj.DeletedAt = null;
            return await AddAsync(obj);
        }

        public async Task<ArtistEntity?> DeleteObjectSync(params object[] id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return null;

            obj.DeletedAt = DateTimeOffset.Now;
            await UpdateObjectAsync(obj);
            return obj;
        }

        public async Task<List<ArtistEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToListAsync();
        }

        public async Task<List<ArtistEntity>> GetArtistsById(string[] ids)
        {
            return await GetAllAsync().Result
                .Where(t => ids.Contains(t.Id))
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Artist.CountAsync();
        }

        public async Task<int> GetCountAsync(string query)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<ArtistEntity, bool>> predicate =
              t => t.Name.Contains(query)
              || t.Description.Contains(query)
              || t.ArtistName.Contains(query)
              && t.DeletedAt == null;

            return await _context.Artist.CountAsync(predicate);
        }

        public async Task<ArtistEntity?> GetObjectAsync(params object[] id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<List<ArtistEntity>> GetTopArtistsAsync(int top)
        {
            return await GetAllAsync().Result
                .Distinct()
                .OrderByDescending(t => t.ArtistSongs.Select(asg => asg.Song.CreatedAt))
                .Take(top)
                .ToListAsync();
        }

        public async Task<List<ArtistEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<ArtistEntity, bool>> predicate =
              t => t.Name.Contains(query)
              || t.Description.Contains(query)
              || t.ArtistName.Contains(query)
              || t.ArtistSongs.Any(t => t.Song.Name.Contains(query))
              || t.ArtistSongs.Any(t => t.Song.AlbumSongs.Any(s => s.Album.Name.Contains(query) || s.Album.Description.Contains(query)))
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.Id)
                    .ToListAsync();
            else
            {
                return await GetAllAsync().Result
                    .Where(predicate).OrderByDescending(t => t.Id)
                    .ToListAsync();
            }
        }

        public async Task<ArtistEntity?> UpdateObjectAsync(ArtistEntity obj)
        {
            return await UpdateAsync(obj);
        }

    }
}
