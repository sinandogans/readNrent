using BookService.Domain.Abstraction;
using System.Linq.Expressions;

namespace BookService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
    }
}
