using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;

namespace BookService.Persistence.EntityFramework.Repositories.PublisherRepository
{
    public class EfPublisherWriteRepository : EfBaseWriteRepository<Publisher, BookServiceContext>, IPublisherWriteRepository
    {
    }
}
