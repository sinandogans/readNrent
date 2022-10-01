using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.LanguageRepository
{
    public class MDBLanguageRepository : MDBBaseRepository<Language>, ILanguageRepository
    {
        private readonly MongoDbContext _context;
        public MDBLanguageRepository(MongoDbContext context) : base(context.LanguagesCollection)
        {
            _context = context;
        }
    }
}
