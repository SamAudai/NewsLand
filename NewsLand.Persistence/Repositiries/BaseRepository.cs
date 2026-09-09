using Microsoft.EntityFrameworkCore;
using NewsLand.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLand.Persistence.Repositiries
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        private readonly PostDbContext _postDbContext;

        public BaseRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _postDbContext.Set<TEntity>().AddAsync(entity);
            await _postDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _postDbContext.Set<TEntity>().Remove(entity);
            await _postDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _postDbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _postDbContext.Set<TEntity>().FindAsync(id) ?? throw new NotImplementedException("Not Found");
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _postDbContext.Entry(entity).State = EntityState.Modified;
            await _postDbContext.SaveChangesAsync();
        }
    }
}
