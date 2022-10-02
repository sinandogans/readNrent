using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookReviewRepository
{
    public interface IBookReviewRepository : IBaseRepository<BookReview>
    {
        Task<BookReview> GetById(Guid id);
        Task<List<BookReview>> GetByBookId(Guid bookId);
        Task DeleteList(List<Guid> ids);
    }
}
