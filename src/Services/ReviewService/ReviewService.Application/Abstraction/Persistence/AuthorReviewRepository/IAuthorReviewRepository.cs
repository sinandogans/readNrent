using ReviewService.Application.Abstraction.Persistence.BaseRepository;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository
{
    public interface IAuthorReviewRepository : IBaseRepository<AuthorReview>
    {
        Task<AuthorReview> GetById(Guid id);
        Task<List<AuthorReview>> GetByAuthorId(Guid authorId);
        Task DeleteList(List<Guid> ids);
    }
}
