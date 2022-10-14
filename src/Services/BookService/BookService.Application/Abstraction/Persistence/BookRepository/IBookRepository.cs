using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetById(Guid id);
        Task<Book> GetByImageId(Guid imageId);
    }
}
