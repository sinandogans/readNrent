using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorRepository
{
    public class TranslatorWriteRepository : EfWriteRepository<Translator, AuthorTranslatorServiceContext>, ITranslatorWriteRepository
    {
    }
}
