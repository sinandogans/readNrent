using ReviewService.Application.Abstraction.Persistence.BaseRepository;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Abstraction.Persistence.BookReviewRepository
{
    public interface IBookReviewRepository : IBaseRepository<BookReview>
    {
        Task<BookReview> GetById(Guid id);
        Task<List<BookReview>> GetByBookId(Guid bookId);
        Task DeleteList(List<Guid> ids);
    }
}
