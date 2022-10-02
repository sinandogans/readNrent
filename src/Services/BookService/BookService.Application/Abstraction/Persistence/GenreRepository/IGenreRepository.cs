using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.GenreRepository
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetParentGenres(Guid genreId);
        Task<List<Genre>> GetSubGenres(Guid genreId);
        Task<Genre> GetById(Guid id);
        Task<Genre> GetBySubGenreId(Guid subgenreId);
    }
}
