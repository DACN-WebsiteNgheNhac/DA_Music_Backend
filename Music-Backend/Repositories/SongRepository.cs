using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class SongRepository : BaseRepository<SongEntity>, ISongRepository
    {
        public async Task<SongEntity> AddDownloadsSong(string songId)
        {
            var data = await GetObjectAsync(false, songId);
            data.Downloads++;
            return await UpdateAsync(data);
        }

        public async Task<SongEntity> AddListensSong(string songId)
        {
            var data = await GetObjectAsync(false, songId);
            data.Listens++;
            return await UpdateAsync(data);
        }

        public async Task<SongEntity?> AddObjectAsync(SongEntity obj)
        {
            if (string.IsNullOrEmpty(obj.Image))
            {
                obj.Image = "https://res.cloudinary.com/thanhle/image/upload/v1697893739/NStore/DefaultIcon/SongMale_npqi8v.jpg";
            }
            obj.Id = Guid.NewGuid().ToString();
            obj.DeletedAt = null;
            return await AddAsync(obj);
        }

        public async Task<SongEntity?> DeleteObjectSync(params object[] id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return null;

            obj.DeletedAt = DateTimeOffset.Now;
            await UpdateObjectAsync(obj);
            return obj;
        }

        public async Task<List<SongEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Song.CountAsync();
        }

        public async Task<SongEntity?> GetObjectAsync(bool includeComment, params object[] id)
        {
            if(!includeComment)
                return await GetAllAsync().Result
                  .Where(t => t.Id == id[0])
                  .FirstOrDefaultAsync();
            return await GetAllAsync().Result
                .Where(t => t.Id == id[0])
                .Include(t => t.Comments).AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<SongEntity?> GetObjectAsync(params object[] id)
        {
            return await GetAllAsync().Result
               .Where(t => t.Id == id[0])
               .Include(t => t.Comments).AsNoTracking()
               .FirstOrDefaultAsync();
        }

        public async Task<List<SongEntity>> GetSongsByArea(string area, int pageNumber, int pageSize)
        {
            area = string.IsNullOrEmpty(area) ? "" : area;

            Expression<Func<SongEntity, bool>> predicate =
              t =>  t.Area.Contains(area.Trim())
              && t.DeletedAt == null;

            if(area == "Other Pop")
                predicate =
                 t => !t.Area.Contains("Vpop")
                 && t.DeletedAt == null;


            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .OrderByDescending(t => t.CreatedAt)
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
            else
            {
                return await GetAllAsync().Result
                    .OrderByDescending(t => t.CreatedAt)
                    .Where(predicate)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
            }
        }

        public async Task<List<SongEntity>> GetSongsByArtistId(string artistId)
        {
            return await _context.Song.AsNoTracking()
                .Include(t => t.ArtistSongs)
                .Where(t => t.ArtistSongs.Any(t => t.ArtistId == artistId))
                .ToListAsync();
        }

        public async Task<List<SongEntity>> GetTopDownloadsSong(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .OrderByDescending(t => t.Downloads)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.Downloads)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .ToListAsync();
        }

        public async Task<List<SongEntity>> GetTopFavoritesSong(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .OrderByDescending(t => t.Favorites.Count)
                    .Include(t => t.Favorites)
                    .ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.Favorites.Count)
                    .Include(t => t.Favorites)
                    .ToListAsync();
        }

        public async Task<List<SongEntity>> GetTopListensSong(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .OrderByDescending(t => t.Listens)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeletedAt == null)
                    .OrderByDescending(t => t.Listens)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist).AsNoTracking()
                    .ToListAsync();
        }

        public async Task<List<SongEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<SongEntity, bool>> predicate =
              t => t.Name.Contains(query)
              || t.Description.Contains(query)
              || t.ArtistSongs.Any(t => t.Artist.Name.Contains(query) || t.Artist.ArtistName.Contains(query))
              || t.AlbumSongs.Any(t => t.Album.Name.Contains(query) || t.Album.Description.Contains(query))
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result                   
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.Id)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
            else
            {
                return await GetAllAsync().Result
                    .Where(predicate).OrderByDescending(t => t.Id)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .ToListAsync();
            }
        }

        public async Task<SongEntity?> UpdateObjectAsync(SongEntity obj)
        {
            return await UpdateAsync(obj);
        }

    }
}
