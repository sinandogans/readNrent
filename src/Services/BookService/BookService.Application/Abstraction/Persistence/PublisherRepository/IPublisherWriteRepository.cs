using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.PublisherRepository
{
    public interface IPublisherWriteRepository : IBaseWriteRepository<Publisher>
    {
    }
}
