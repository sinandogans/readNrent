using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookReadRepository : IBaseReadRepository<Book>
    {
        public Task<Book> GetById(Guid id);
    }
}
