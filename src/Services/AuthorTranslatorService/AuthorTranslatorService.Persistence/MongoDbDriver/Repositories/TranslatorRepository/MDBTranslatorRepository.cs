using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.TranslatorRepository
{
    public class MDBTranslatorRepository : MDBBaseRepository<Translator>, ITranslatorRepository
    {
        private readonly IMongoCollection<Translator> _collection;
        private readonly IMongoDatabase _database;
        private readonly IOptions<MongoDbOptions> _dbOptions;

        public MDBTranslatorRepository(IOptions<MongoDbOptions> dbOptions) : base(
            dbOptions,
            dbOptions.Value.TranslatorCollectionName)
        {
            _dbOptions = dbOptions;
            MongoClient client = new MongoClient(_dbOptions.Value.ConnectionString);
            _database = client.GetDatabase(_dbOptions.Value.DbName);
            _collection = _database.GetCollection<Translator>(_dbOptions.Value.TranslatorCollectionName);
        }
        public async Task AddReview(TranslatorReview review)
        {
            var reviewCollection = _database.GetCollection<TranslatorReview>(_dbOptions.Value.TranslatorReviewCollectionName);
            await reviewCollection.InsertOneAsync(review);

            var translator = await _collection.Find(a => a.Id == review.TranslatorId).SingleOrDefaultAsync();
            translator.ReviewIds.Add(review.Id);
            translator.Rating = ((translator.Rating * translator.ReviewCount) + review.Rating) / (translator.ReviewCount + 1);
            translator.ReviewCount++;

            await this.Update(translator);
        }
        public async Task<Translator> GetById(Guid id)
        {
            var translator = await _collection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return translator;
        }
        public async Task<List<TranslatorReview>> GetReviews(Guid id)
        {
            var reviewCollection = _database.GetCollection<TranslatorReview>(_dbOptions.Value.TranslatorReviewCollectionName);
            var reviews = await reviewCollection.Find(r => r.TranslatorId == id).ToListAsync();
            return reviews;
        }
    }
}
