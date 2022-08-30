using AuthorTranslatorService.Domain.Abstraction.Entity;
using System.Linq.Expressions;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base
{
    public interface IReadRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null!);
    }
}
