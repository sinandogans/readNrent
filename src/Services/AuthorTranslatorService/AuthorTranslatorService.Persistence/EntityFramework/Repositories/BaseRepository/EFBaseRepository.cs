using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Abstraction.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.BaseRepository
{
    public abstract class EFBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            using (TContext context = new TContext())
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
