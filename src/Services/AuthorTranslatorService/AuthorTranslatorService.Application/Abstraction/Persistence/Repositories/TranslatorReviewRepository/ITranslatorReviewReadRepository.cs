using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository
{
    public interface ITranslatorReviewReadRepository : IReadRepository<TranslatorReview>
    {
    }
}