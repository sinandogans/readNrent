using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository
{
    public interface IAuthorReadRepository : IReadRepository<Author>
    {
        Task<List<AuthorReview>> GetAuthorReviews(Guid id);
    }
}