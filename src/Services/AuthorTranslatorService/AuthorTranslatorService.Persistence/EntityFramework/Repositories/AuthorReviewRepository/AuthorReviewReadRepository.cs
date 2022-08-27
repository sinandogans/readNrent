using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorReviewRepository
{
    public class AuthorReviewReadRepository : EfReadRepository<AuthorReview, AuthorTranslatorServiceContext>, IAuthorReviewReadRepository
    {
    }
}
