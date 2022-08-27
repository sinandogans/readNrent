using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorRepository
{
    public class AuthorWriteRepository : EfWriteRepository<Author, AuthorTranslatorServiceContext>,IAuthorWriteRepository
    {
    }
}
