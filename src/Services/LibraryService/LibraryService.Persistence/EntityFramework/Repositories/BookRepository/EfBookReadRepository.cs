using LibraryService.Application.Abstraction.Persistence.BookRepository;
using LibraryService.Domain.Entities;
using LibraryService.Persistence.EntityFramework.Contexts;
using LibraryService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace LibraryService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class EfBookReadRepository : EfBaseReadRepository<Book, LibraryServiceContext>, IBookReadRepository
    {
        public async Task<Book> GetById(Guid id)
        {
            return await this.Get(b => b.Id == id);
        }
    }
}
