using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.LanguageRepository
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        Task<Language> GetById(Guid id);
    }
}
