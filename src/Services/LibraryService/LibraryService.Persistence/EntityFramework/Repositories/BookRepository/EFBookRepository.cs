using LibraryService.Application.Abstraction.Persistence.BookRepository;
using LibraryService.Domain.Entities;
using LibraryService.Persistence.EntityFramework.Contexts;
using LibraryService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace LibraryService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class EFBookRepository : EFBaseRepository<Book, LibraryServiceContext>, IBookRepository
    {
        public async Task<Book> GetById(Guid id)
        {
            return await this.Get(b => b.Id == id);
        }
    }
}
