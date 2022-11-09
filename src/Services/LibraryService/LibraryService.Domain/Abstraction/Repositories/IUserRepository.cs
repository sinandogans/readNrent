using LibraryService.Domain.AggregatesModel.UserAggregate;

namespace LibraryService.Domain.Abstraction.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetById(Guid id);
}