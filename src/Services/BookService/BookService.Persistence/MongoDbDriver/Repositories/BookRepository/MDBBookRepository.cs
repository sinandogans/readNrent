using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.BookRepository
{
    public class MDBBookRepository : MDBBaseRepository<Book>, IBookRepository
    {
        private readonly MongoDbContext _context;
        public MDBBookRepository(MongoDbContext context) : base(context.BooksCollection)
        {
            _context = context;
        }

        public async Task<Book> GetById(Guid id)
        {
            var book = await this.Get(b => b.Id == id);
            return book;
        }

        public async Task<Book> GetByImageId(Guid imageId)
        {
            var book = await this.Get(a => a.ImageIds.Contains(imageId));
            return book;
        }
    }
}
