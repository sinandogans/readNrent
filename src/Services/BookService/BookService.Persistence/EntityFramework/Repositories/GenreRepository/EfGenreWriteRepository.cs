using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;

namespace BookService.Persistence.EntityFramework.Repositories.GenreRepository
{
    public class EfGenreWriteRepository : EfBaseWriteRepository<Genre, BookServiceContext>, IGenreWriteRepository
    {
    }
}
