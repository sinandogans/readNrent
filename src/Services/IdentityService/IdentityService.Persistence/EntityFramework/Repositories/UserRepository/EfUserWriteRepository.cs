using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.EntityFramework.Contexts;
using IdentityService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace IdentityService.Persistence.EntityFramework.Repositories.UserRepository
{
    public class EfUserWriteRepository : EfBaseWriteRepository<User, IdentityServiceContext>, IUserWriteRepository
    {
    }
}
