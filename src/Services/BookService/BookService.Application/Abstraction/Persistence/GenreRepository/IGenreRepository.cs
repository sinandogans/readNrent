using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.GenreRepository
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        public Task<List<Genre>> GetParentGenres(Guid genreId);
    }
}
