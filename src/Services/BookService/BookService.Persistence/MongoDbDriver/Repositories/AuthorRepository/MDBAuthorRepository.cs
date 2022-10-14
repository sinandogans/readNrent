using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.AuthorRepository
{
    public class MDBAuthorRepository : MDBBaseRepository<Author>, IAuthorRepository
    {
        private readonly MongoDbContext _context;

        public MDBAuthorRepository(MongoDbContext context) : base(context.AuthorsCollection)
        {
            _context = context;
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await this.Get(a => a.Id == id);
            return author;
        }
    }
}
