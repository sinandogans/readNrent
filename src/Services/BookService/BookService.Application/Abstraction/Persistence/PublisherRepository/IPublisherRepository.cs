using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Abstraction.Persistence.PublisherRepository
{
    public interface IPublisherRepository : IBaseRepository<Publisher>
    {
        Task<Publisher> GetById(Guid id);

    }
}
