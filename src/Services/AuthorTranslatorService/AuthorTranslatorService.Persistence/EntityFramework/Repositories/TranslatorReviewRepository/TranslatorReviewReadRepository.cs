using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorReviewRepository
{
    public class TranslatorReviewReadRepository : EfReadRepository<TranslatorReview, AuthorTranslatorServiceContext>, ITranslatorReviewReadRepository
    {
    }
}
