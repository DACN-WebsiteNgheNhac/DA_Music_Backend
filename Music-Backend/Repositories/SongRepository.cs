﻿using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class SongRepository : BaseRepository<SongEntity>, ISongRepository
    {
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
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .OrderByDescending(t => t.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(t => t.DeletedAt == null)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Song.CountAsync();
        }

        public async Task<SongEntity?> GetObjectAsync(params object[] id)
        {
            return await GetAllAsync().Result
                .Where(t => t.Id == id[0])
                .Include(t => t.Comments)
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
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .ToListAsync();
            else
            {
                return await GetAllAsync().Result
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .Where(predicate)
                    .ToListAsync();
            }
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
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.Id)
                    .ToListAsync();
            else
            {
                return await GetAllAsync().Result
                    .Include(t => t.ArtistSongs)
                    .ThenInclude(t => t.Artist)
                    .Where(predicate).OrderByDescending(t => t.Id)
                    .ToListAsync();
            }
        }

        public async Task<SongEntity?> UpdateObjectAsync(SongEntity obj)
        {
            return await UpdateAsync(obj);
        }

    }
}
