using System.Linq.Expressions;

namespace LibraryService.Domain.Abstraction.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
}