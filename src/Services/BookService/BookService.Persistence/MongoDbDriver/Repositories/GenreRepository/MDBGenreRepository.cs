using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.GenreRepository
{
    public class MDBGenreRepository : MDBBaseRepository<Genre>, IGenreRepository
    {
        private readonly MongoDbContext _context;
        public MDBGenreRepository(MongoDbContext context) : base(context.GenresCollection)
        {
            _context = context;
        }

        public Task<List<Genre>> GetParentGenres(Guid genreId)
        {
            throw new NotImplementedException();
        }
    }
}
