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

            var author = await _context.AuthorsCollection.Find(a => a.Id == review.AuthorId).SingleOrDefaultAsync();
            author.ReviewIds.Add(review.Id);
            author.Rating = ((author.Rating * author.ReviewCount) + review.Rating) / (author.ReviewCount + 1);
            author.ReviewCount++;

            await this.Update(author);
        }

        public async Task DeleteReview(Guid reviewId)
        {
            var review = await _context.AuthorReviewsCollection.Find(r => r.Id == reviewId).FirstOrDefaultAsync();
            var author = await _context.AuthorsCollection.Find(a => a.ReviewIds.Contains(reviewId)).SingleOrDefaultAsync();

            author.Rating = ((author.Rating * author.ReviewCount) - review.Rating) / (author.ReviewCount - 1);
            author.ReviewCount--;

            author.ReviewIds.Remove(reviewId);
            await _context.AuthorReviewsCollection.DeleteOneAsync(r => r.Id == reviewId);
            await this.Update(author);
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _context.AuthorsCollection.Find(a => a.Id == id).SingleOrDefaultAsync();
            return author;
        }

        public async Task<List<AuthorReview>> GetReviews(Guid id)
        {
            var reviews = await _context.AuthorReviewsCollection.Find(r => r.AuthorId == id).ToListAsync();
            return reviews;
        }
    }
}
