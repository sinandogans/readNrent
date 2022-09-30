using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository
{
    public interface ITranslatorReviewRepository : IBaseRepository<TranslatorReview>
    {
        Task<TranslatorReview> GetById(Guid id);
        Task<List<TranslatorReview>> GetByTranslatorId(Guid translatorId);
        Task DeleteList(List<Guid> ids);
    }
}
