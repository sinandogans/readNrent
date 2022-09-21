using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using BookService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace BookService.Persistence.EntityFramework.Repositories.LanguageRepository
{
    public class EFLanguageRepository : EfBaseRepository<Language, BookServiceContext>, ILanguageRepository
    {
    }
}
