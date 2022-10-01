using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.TranslatorReviewRepository
{
    public interface ITranslatorReviewRepository : IBaseRepository<TranslatorReview>
    {
        Task<TranslatorReview> GetById(Guid id);
        Task<List<TranslatorReview>> GetByTranslatorId(Guid translatorId);
        Task DeleteList(List<Guid> ids);
    }
}
