using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository
{
    public interface IAuthorReviewReadRepository : IReadRepository<AuthorReview>
    {
    }
}