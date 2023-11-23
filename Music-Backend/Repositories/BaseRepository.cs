using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Music_Backend.Data;
using Music_Backend.Exceptions;
using Music_Backend.Models.Entities;

namespace Music_Backend.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected BaseRepository()
        {
            _context = new DataContext();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            try
            {
                return _context.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error getting entity: {ex.InnerException}");
            }
        }
      

        public async Task<T?> GetByIdAsync(params object[] Id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(Id);
                return entity;
            }
            catch
            {
                return null;
            }
        }


        public async Task<T?> GetByIdWithIncludeAsync(Expression<Func<T, bool>> predicate
            , string[] includes, params object[] Id)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();

                foreach (var prop in includes)
                {
                    query = query.Include(prop);
                }

                var entity = await query.Where(predicate).FirstOrDefaultAsync();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var existed = await _context.Set<T>().Where(t => t == entity).FirstOrDefaultAsync();
                if (existed != null)
                {
                    if(existed is EntityWithoutKey)
                    {
                        (existed as EntityWithoutKey).DeletedAt = null;
                        await _context.SaveChangesAsync();

                    }
                    return existed;
                }
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error adding entity: {ex.InnerException}");
            }
        }

        public async Task<List<T>> AddMultiAsync(List<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error adding entity: {ex.InnerException}");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
        }

        public async Task RemoveRange(params T[] items)
        {
            try
            {
                _context.Set<T>().RemoveRange(items);
                await _context.SaveChangesAsync();               
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
        }

        public async Task AddRange(ICollection<T> items)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
        }

        public async Task<T?> DeleteAsync(params object[] id)
        {
            var item = default(T);
            try
            {
                item = await _context.Set<T>().FindAsync(id);
                _context.Set<T>().RemoveRange(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return default(T);
                throw new ActionDatabaseException($"Error updating entity: {ex.Message}");
            }
            return item;
        }
    }
}
