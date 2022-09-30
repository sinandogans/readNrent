using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository
{
    public interface IAuthorReviewRepository : IBaseRepository<AuthorReview>
    {
        Task<AuthorReview> GetById(Guid id);
        Task<List<AuthorReview>> GetByAuthorId(Guid authorId);
        Task DeleteList(List<Guid> ids);
    }
}
