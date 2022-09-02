using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.GenreRepository
{
    public interface IGenreReadRepository : IBaseReadRepository<Genre>
    {
        public Task<List<Genre>> GetParentGenres(Guid genreId);
    }
}
