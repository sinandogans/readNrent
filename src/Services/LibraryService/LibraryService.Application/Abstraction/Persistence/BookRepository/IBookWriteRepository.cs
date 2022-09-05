using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookWriteRepository : IBaseWriteRepository<Book>
    {
    }
}
