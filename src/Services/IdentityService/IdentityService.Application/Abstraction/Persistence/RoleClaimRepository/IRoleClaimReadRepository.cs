using IdentityService.Application.Abstraction.Persistence.BaseRepository;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction.Persistence.RoleClaimRepository
{
    public interface IRoleClaimReadRepository : IBaseReadRepository<RoleClaim>
    {
        Task<RoleClaim> GetById(Guid id);
    }
}
