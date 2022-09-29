using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using MongoDB.Driver;

namespace AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.AuthorRepository
{
    public class MDBAuthorRepository : MDBBaseRepository<Author>, IAuthorRepository
    {
        private readonly MongoDbContext _context;

        public MDBAuthorRepository(MongoDbContext context) : base(context.AuthorsCollection)
        {
            _context = context;
        }
        public async Task AddReview(AuthorReview review)
        {
            await _context.AuthorReviewsCollection.InsertOneAsync(review);
        }

        public async Task DeleteReview(Guid reviewId)
        {
            await _context.AuthorReviewsCollection.DeleteOneAsync(r => r.Id == reviewId);
        }

        public async Task DeleteReviews(List<Guid> reviewIds)
        {
            foreach (var reviewId in reviewIds)
                await this.DeleteReview(reviewId);
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _context.AuthorsCollection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return author;
        }

        public async Task<Author> GetByReviewId(Guid reviewId)
        {
            var author = await _context.AuthorsCollection.Find(a => a.ReviewIds.Contains(reviewId)).SingleOrDefaultAsync();
            return author;
        }

        public async Task<AuthorReview> GetReviewById(Guid id)
        {
            var review = await _context.AuthorReviewsCollection.Find(r => r.Id == id).SingleOrDefaultAsync();
            return review;
        }

        public async Task<List<AuthorReview>> GetReviews(Guid id)
        {
            var reviews = await _context.AuthorReviewsCollection.Find(r => r.AuthorId == id).ToListAsync();
            return reviews;
        }

        public async Task UpdateReview(AuthorReview review)
        {
            await _context.AuthorReviewsCollection.ReplaceOneAsync(r => r.Id == review.Id, review);
        }
    }
}
