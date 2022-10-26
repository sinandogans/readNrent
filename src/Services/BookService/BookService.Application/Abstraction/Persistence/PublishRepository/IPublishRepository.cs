using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Abstraction.Persistence.PublishRepository
{
    public interface IPublishRepository : IBaseRepository<Publish>
    {
    }
}
