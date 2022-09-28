using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.AuthorRepository
{
    public class MDBAuthorRepository : MDBBaseRepository<Author>, IAuthorRepository
    {
        private readonly IMongoCollection<Author> _collection;
        private readonly IMongoDatabase _database;
        private readonly IOptions<MongoDbOptions> _dbOptions;

        public MDBAuthorRepository(IOptions<MongoDbOptions> dbOptions) : base(
            dbOptions,
            dbOptions.Value.AuthorCollectionName)
        {
            _dbOptions = dbOptions;
            MongoClient client = new MongoClient(_dbOptions.Value.ConnectionString);
            _database = client.GetDatabase(_dbOptions.Value.DbName);
            _collection = _database.GetCollection<Author>(_dbOptions.Value.AuthorCollectionName);
        }
        public async Task AddReview(AuthorReview review)
        {
            var reviewCollection = _database.GetCollection<AuthorReview>(_dbOptions.Value.AuthorReviewCollectionName);
            await reviewCollection.InsertOneAsync(review);

            var author = await _collection.Find(a => a.Id == review.AuthorId).SingleOrDefaultAsync();
            author.ReviewIds.Add(review.Id);
            author.Rating = ((author.Rating * author.ReviewCount) + review.Rating) / (author.ReviewCount + 1);
            author.ReviewCount++;

            await this.Update(author);
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _collection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return author;
        }

        public async Task<List<AuthorReview>> GetReviews(Guid id)
        {
            var reviewCollection = _database.GetCollection<AuthorReview>(_dbOptions.Value.AuthorReviewCollectionName);
            var reviews = await reviewCollection.Find(r => r.AuthorId == id).ToListAsync();
            return reviews;
        }
    }
}
