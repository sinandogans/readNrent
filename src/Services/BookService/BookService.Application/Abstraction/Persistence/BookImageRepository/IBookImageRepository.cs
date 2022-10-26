using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Abstraction.Persistence.BookImageRepository
{
    public interface IBookImageRepository : IBaseRepository<BookImage>
    {
    }
}
