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
        private readonly MongoDbContext _context;


        public MDBTranslatorRepository(IOptions<MongoDbOptions> dbOptions, MongoDbContext context) : base(context.TranslatorsCollection)
        {
            _context = context;
        }
        public async Task AddReview(TranslatorReview review)
        {
            await _context.TranslatorReviewsCollection.InsertOneAsync(review);

            var translator = await _context.TranslatorsCollection.Find(a => a.Id == review.TranslatorId).SingleOrDefaultAsync();
            translator.ReviewIds.Add(review.Id);
            translator.Rating = ((translator.Rating * translator.ReviewCount) + review.Rating) / (translator.ReviewCount + 1);
            translator.ReviewCount++;

            await this.Update(translator);
        }
        public async Task DeleteReview(Guid reviewId)
        {
            var review = await _context.TranslatorReviewsCollection.Find(r => r.Id == reviewId).FirstOrDefaultAsync();
            var translator = await _context.TranslatorsCollection.Find(a => a.ReviewIds.Contains(reviewId)).SingleOrDefaultAsync();

            translator.Rating = ((translator.Rating * translator.ReviewCount) - review.Rating) / (translator.ReviewCount - 1);
            translator.ReviewCount--;

            translator.ReviewIds.Remove(reviewId);
            await _context.TranslatorReviewsCollection.DeleteOneAsync(r => r.Id == reviewId);
            await this.Update(translator);
        }

        public async Task<Translator> GetById(Guid id)
        {
            var translator = await _context.TranslatorsCollection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return translator;
        }
        public async Task<List<TranslatorReview>> GetReviews(Guid id)
        {
            var reviews = await _context.TranslatorReviewsCollection.Find(r => r.TranslatorId == id).ToListAsync();
            return reviews;
        }
    }
}
