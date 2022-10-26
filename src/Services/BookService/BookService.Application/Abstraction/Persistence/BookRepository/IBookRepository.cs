using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Abstraction.Persistence.BookRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetById(Guid id);
        Task<Book> GetByReviewId(Guid reviewId);
        Task<Book> GetByImageId(Guid imageId);

    }
}
