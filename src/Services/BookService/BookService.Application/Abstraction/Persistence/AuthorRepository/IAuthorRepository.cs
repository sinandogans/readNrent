using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.AuthorAggregate;

namespace BookService.Application.Abstraction.Persistence.AuthorRepository
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<Author> GetById(Guid id);
        Task<Author> GetByReviewId(Guid reviewId);
    }
}
