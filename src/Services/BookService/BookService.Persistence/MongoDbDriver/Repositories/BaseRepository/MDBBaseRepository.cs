using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Abstraction;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace BookService.Persistence.MongoDbDriver.Repositories.BaseRepository
{
    public abstract class MDBBaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IMongoCollection<TEntity> _collection;

        protected MDBBaseRepository(IMongoCollection<TEntity> collection)
        {
            _collection = collection;
        }

        public async Task Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var deleteFilter = Builders<TEntity>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(deleteFilter);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> data;
            data =
                filter != null
                ? await _collection.Find(filter).ToListAsync()
                : await _collection.Find(d => true).ToListAsync();
            return data;
        }

        public async Task Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}
