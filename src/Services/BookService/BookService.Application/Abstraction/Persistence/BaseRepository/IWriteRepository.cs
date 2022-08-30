using BookService.Domain.Abstraction;

namespace BookService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
    }
}
