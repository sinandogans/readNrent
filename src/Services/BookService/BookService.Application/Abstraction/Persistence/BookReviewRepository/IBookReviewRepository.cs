using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.BookReviewRepository
{
    public interface IBookReviewRepository : IBaseRepository<BookReview>
    {
    }
}
