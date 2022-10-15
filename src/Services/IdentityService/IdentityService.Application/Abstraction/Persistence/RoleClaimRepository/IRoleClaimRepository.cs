using IdentityService.Application.Abstraction.Persistence.BaseRepository;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction.Persistence.RoleClaimRepository
{
    public interface IRoleClaimRepository : IBaseRepository<RoleClaim>
    {
        Task<RoleClaim> GetById(Guid id);
    }
}
