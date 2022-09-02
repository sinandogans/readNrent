using BookService.Domain.Abstraction;
using System.Linq.Expressions;

namespace BookService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IBaseReadRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
    }
}
