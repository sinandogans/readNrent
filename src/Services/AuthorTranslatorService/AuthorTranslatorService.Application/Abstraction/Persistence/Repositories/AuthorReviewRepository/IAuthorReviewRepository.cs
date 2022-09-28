using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository
{
    public interface IAuthorReviewRepository : IBaseRepository<AuthorReview>
    {
    }
}
