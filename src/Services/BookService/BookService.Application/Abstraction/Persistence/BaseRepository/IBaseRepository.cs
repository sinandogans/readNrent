using BookService.Domain.Abstraction;
using System.Linq.Expressions;

namespace BookService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
    }
}
