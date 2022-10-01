using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.AuthorReviewRepository
{
    public interface IAuthorReviewRepository : IBaseRepository<AuthorReview>
    {
        Task<AuthorReview> GetById(Guid id);
        Task<List<AuthorReview>> GetByAuthorId(Guid authorId);
        Task DeleteList(List<Guid> ids);
    }
}
