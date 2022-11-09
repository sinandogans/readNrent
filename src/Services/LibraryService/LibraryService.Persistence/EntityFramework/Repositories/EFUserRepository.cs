using LibraryService.Domain.Abstraction.Repositories;
using LibraryService.Domain.AggregatesModel.UserAggregate;
using LibraryService.Persistence.EntityFramework.Contexts;

namespace LibraryService.Persistence.EntityFramework.Repositories;

public class EFUserRepository : EFBaseRepository<User, LibraryServiceContext>, IUserRepository
{
    public async Task<User> GetById(Guid id)
    {
        return await this.Get(u => u.Id == id);
    }
}