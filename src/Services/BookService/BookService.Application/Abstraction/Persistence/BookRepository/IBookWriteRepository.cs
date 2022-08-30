using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookWriteRepository : IWriteRepository<Book>
    {
        Task AddBookReview(BookReview bookReview);
        Task AddBookPublish(Publish publish);
        Task AddBookLanguage(Guid bookId, Guid languageId);
    }
}
