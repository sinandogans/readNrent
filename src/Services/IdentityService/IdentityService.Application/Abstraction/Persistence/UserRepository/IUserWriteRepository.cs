using IdentityService.Application.Abstraction.Persistence.BaseRepository;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction.Persistence.UserRepository
{
    public interface IUserWriteRepository : IBaseWriteRepository<User>
    {
    }
}
