using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;
using ReviewService.Domain.Entities;
using ReviewService.Persistence.MongoDbDriver.Context;
using ReviewService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace ReviewService.Persistence.MongoDbDriver.Repositories.BookReviewRepository
{
    public class MDBBookReviewRepository : MDBBaseRepository<BookReview>, IBookReviewRepository
    {
        private readonly MongoDbContext _context;
        public MDBBookReviewRepository(MongoDbContext context) : base(context.BookReviewsCollection)
        {
            _context = context;
        }

        public async Task DeleteList(List<Guid> ids)
        {
            foreach (var id in ids)
                await Delete(id);
        }

        public async Task<List<BookReview>> GetByBookId(Guid bookId)
        {
            var reviews = await GetList(r => r.BookId == bookId);
            return reviews;
        }

        public async Task<BookReview> GetById(Guid id)
        {
            var review = await Get(r => r.Id == id);
            return review;
        }
    }
}
