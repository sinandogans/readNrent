using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Persistence.EntityFramework.Repositories.BaseRepository
{
    public class EfBaseWriteRepository<TEntity, TContext> : IBaseWriteRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
