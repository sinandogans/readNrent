using AuthorTranslatorService.Domain.Abstraction.Entity;
using System.Linq.Expressions;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
    }
}
