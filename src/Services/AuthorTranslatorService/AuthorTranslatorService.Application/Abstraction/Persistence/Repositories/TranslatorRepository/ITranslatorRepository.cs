using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository
{
    public interface ITranslatorRepository : IBaseRepository<Translator>
    {
        Task AddReview(TranslatorReview review);
    }
}
