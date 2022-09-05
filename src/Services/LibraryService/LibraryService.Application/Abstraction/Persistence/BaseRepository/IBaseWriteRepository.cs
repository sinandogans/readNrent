using LibraryService.Domain.Abstraction;

namespace LibraryService.Application.Abstraction.Persistence.BaseRepository
{
    public interface IBaseWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
    }
}
