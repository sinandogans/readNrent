using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        public Task<Book> GetById(Guid id);
    }
}
