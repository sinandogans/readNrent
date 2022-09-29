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
        }
        public async Task DeleteReview(Guid reviewId)
        {
            await _context.TranslatorReviewsCollection.DeleteOneAsync(r => r.Id == reviewId);
        }

        public async Task DeleteReviews(List<Guid> reviewIds)
        {
            foreach (var reviewId in reviewIds)
                await this.DeleteReview(reviewId);
        }

        public async Task<Translator> GetById(Guid id)
        {
            var translator = await _context.TranslatorsCollection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return translator;
        }

        public async Task<Translator> GetByReviewId(Guid reviewId)
        {
            var translator = await _context.TranslatorsCollection.Find(a => a.ReviewIds.Contains(reviewId)).SingleOrDefaultAsync();
            return translator;
        }

        public async Task<TranslatorReview> GetReviewById(Guid id)
        {
            var review = await _context.TranslatorReviewsCollection.Find(r => r.Id == id).SingleOrDefaultAsync();
            return review;
        }

        public async Task<List<TranslatorReview>> GetReviews(Guid id)
        {
            var reviews = await _context.TranslatorReviewsCollection.Find(r => r.TranslatorId == id).ToListAsync();
            return reviews;
        }

        public async Task UpdateReview(TranslatorReview review)
        {
            await _context.TranslatorReviewsCollection.ReplaceOneAsync(r => r.Id == review.Id, review);
        }
    }
}
