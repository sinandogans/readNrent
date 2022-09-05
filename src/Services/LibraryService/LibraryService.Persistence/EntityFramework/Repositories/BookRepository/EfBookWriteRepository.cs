using LibraryService.Application.Abstraction.Persistence.BookRepository;
using LibraryService.Domain.Entities;
using LibraryService.Persistence.EntityFramework.Contexts;
using LibraryService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace LibraryService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class EfBookWriteRepository : EfBaseWriteRepository<Book, LibraryServiceContext>, IBookWriteRepository
    {
    }
}
