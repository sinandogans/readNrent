using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository
{
    public interface ITranslatorWriteRepository : IWriteRepository<Translator>
    {
    }
}
