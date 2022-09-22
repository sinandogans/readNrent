using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using BookService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace BookService.Persistence.EntityFramework.Repositories.PublisherRepository
{
    public class EFPublisherRepository : EFBaseRepository<Publisher, BookServiceContext>, IPublisherRepository
    {
    }
}
