using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using BookService.Domain.Entities;
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
    }
}
