﻿using Microsoft.EntityFrameworkCore;
using Music_Backend.Models.Entities;
using Music_Backend.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Music_Backend.Repositories
{
    public class AlbumRepository : BaseRepository<AlbumEntity>, IAlbumRepository
    {
        public async Task<AlbumEntity?> AddObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumEntity?> DeleteObjectSync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AlbumEntity>> GetAlbumsByArtistIdAsync(string albumId)
        {
            return await _context.Album.AsNoTracking()
                .Where(t => t.AlbumSongs.Any(t => t.Song.ArtistSongs.Any(t => t.ArtistId == albumId)))
                .Include(t => t.AlbumSongs)
                .ThenInclude(t => t.Song)
                .ThenInclude(t => t.ArtistSongs).AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<AlbumEntity>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await GetAllAsync().Result.ToListAsync();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountByTopicIdAsync(string topicId)
        {
            topicId = topicId == null ? string.Empty : topicId;

            Expression<Func<AlbumEntity, bool>> predicate =
              t => t.Topic.Id.Contains(topicId)
              && t.DeletedAt == null;

            return await _context.Album.Where(predicate).CountAsync();
        }

        public async Task<AlbumEntity?> GetObjectAsync(params object[] id)
        {
            return await GetAllAsync().Result.Where(t => t.Id == id[0])
                .Include(t => t.Topic)
                .Include(t => t.AlbumSongs)
                .ThenInclude(t => t.Song)
                .ThenInclude(t => t.ArtistSongs)
                .ThenInclude(t => t.Artist)
                .FirstOrDefaultAsync();
        }

        public async Task<List<AlbumEntity>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1)
        {
            query = string.IsNullOrEmpty(query) ? "" : query;

            Expression<Func<AlbumEntity, bool>> predicate =
              t => t.Name.Contains(query)
              || t.Description.Contains(query)
              || t.AlbumSongs.Any(temp => temp.Song.Name.Contains(query))
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                    .OrderByDescending(t => t.CreatedAt)
                    .Include(t => t.AlbumSongs)
                    .ThenInclude(t => t.Song)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Include(t => t.AlbumSongs)
                    .ThenInclude(t => t.Song)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToListAsync();
        }

        public async Task<List<AlbumEntity>> SearchObjectByTopicIdAsync(string topicId, int pageNumber = -1, int pageSize = -1)
        {
            topicId = topicId == null ? string.Empty : topicId;

            Expression<Func<AlbumEntity, bool>> predicate =
              t => t.Topic.Id.Contains(topicId)
              && t.DeletedAt == null;

            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.Id)
                    .Include(t => t.Topic)
                    .Include(t => t.AlbumSongs)
                    .ThenInclude(t => t.Song)
                    .ThenInclude(t => t.ArtistSongs)
                    .ToListAsync();
            else
                return await GetAllAsync().Result
                    .Where(predicate)
                    .Include(t => t.Topic)
                    .Include(t => t.AlbumSongs)
                    .ThenInclude(t => t.Song)
                    .ThenInclude(t => t.ArtistSongs)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
        }

        public Task<AlbumEntity?> UpdateObjectAsync(AlbumEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
