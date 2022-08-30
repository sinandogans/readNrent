using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using BookService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace BookService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class BookReadRepository : EfReadRepository<Book, BookServiceContext>, IBookReadRepository
    {

    }
}
