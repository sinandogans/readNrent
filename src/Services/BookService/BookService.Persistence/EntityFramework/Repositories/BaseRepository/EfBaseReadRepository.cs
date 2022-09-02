using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookService.Persistence.EntityFramework.Repositories.BaseRepository
{
    public class EfBaseReadRepository<TEntity, TContext> : IBaseReadRepository<TEntity>
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
    }
}
