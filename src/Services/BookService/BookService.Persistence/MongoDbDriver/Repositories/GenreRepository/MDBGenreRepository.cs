using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.AggregatesModel.BookAggregate;
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

        public async Task<List<Genre>> GetParentGenres(Guid genreId)
        {
            List<Genre> genres = new List<Genre>();
            var genre = await this.GetById(genreId);
            while (genre.ParentId != null)
            {
                var parentGenre = await this.GetById((Guid)genre.ParentId);
                genres.Add(parentGenre);
                genre = parentGenre;
            }
            return genres;
        }
        public async Task<Genre> GetById(Guid id)
        {
            var genre = await this.Get(a => a.Id == id);
            return genre;
        }

        public async Task<Genre> GetBySubGenreId(Guid subgenreId)
        {
            var genre = await this.Get(g => g.SubGenreIds.Contains(subgenreId));
            return genre;
        }

        public async Task<List<Genre>> GetSubGenres(Guid genreId)
        {
            List<Guid> genreIds = new List<Guid>();
            var genre = await this.GetById(genreId);
            genreIds.AddRange(genre.SubGenreIds);

            foreach (var subgenreId in genreIds.ToList())
            {
                var subgenre = await this.GetById(subgenreId);
                genreIds.AddRange(subgenre.SubGenreIds);
            }
            List<Genre> genres = new List<Genre>();
            foreach (var subgenreId in genreIds)
            {
                genres.Add(await this.GetById(subgenreId));
            }

            return genres;
        }
    }
}
