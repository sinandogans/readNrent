using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookImageRepository
{
    public interface IBookImageRepository : IBaseRepository<BookImage>
    {
    }
}
