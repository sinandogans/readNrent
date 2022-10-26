using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.AggregatesModel.UserAggregate;

namespace BookService.Application.Abstraction.Persistence.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(Guid id);
    }
}
