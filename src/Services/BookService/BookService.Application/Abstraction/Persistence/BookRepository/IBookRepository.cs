using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task AddBookReview(BookReview bookReview);
        Task AddPublish(Publish publish);
        Task AddBookImage(BookImage bookImage);
        Task<Book> AddAuthor(Guid bookId, Guid authorId);
        Task<Book> AddTranslator(Guid bookId, Guid translatorId);

        Task<Book> GetById(Guid id);
    }
}
