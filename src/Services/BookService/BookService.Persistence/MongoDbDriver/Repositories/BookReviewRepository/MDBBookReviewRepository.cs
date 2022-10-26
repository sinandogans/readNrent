using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using BookService.Domain.AggregatesModel.BookAggregate;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.BookReviewRepository
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
                await this.Delete(id);
        }

        public async Task<List<BookReview>> GetByBookId(Guid bookId)
        {
            var reviews = await this.GetList(r => r.BookId == bookId);
            return reviews;
        }

        public async Task<BookReview> GetById(Guid id)
        {
            var review = await this.Get(r => r.Id == id);
            return review;
        }
    }
}
