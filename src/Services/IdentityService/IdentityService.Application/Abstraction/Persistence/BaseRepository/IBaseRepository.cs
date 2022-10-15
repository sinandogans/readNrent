using IdentityService.Domain.Abstraction;
using System.Linq.Expressions;

namespace IdentityService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
    }
}
