using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
    }
}
