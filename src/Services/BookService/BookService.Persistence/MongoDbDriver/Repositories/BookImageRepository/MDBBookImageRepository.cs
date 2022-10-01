using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.BookImageRepository
{
    public class MDBBookImageRepository : MDBBaseRepository<BookImage>, IBookImageRepository
    {
        private readonly MongoDbContext _context;
        public MDBBookImageRepository(MongoDbContext context) : base(context.BookImagesCollection)
        {
            _context = context;
        }
    }
}
