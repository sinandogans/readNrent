using IdentityService.Application.Abstraction.Persistence.RoleClaimRepository;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.EntityFramework.Contexts;
using IdentityService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace IdentityService.Persistence.EntityFramework.Repositories.RoleClaimRepository
{
    public class EFRoleClaimRepository : EFBaseRepository<RoleClaim, IdentityServiceContext>, IRoleClaimRepository
    {
        public async Task<RoleClaim> GetById(Guid id)
        {
            var user = await this.Get(u => u.Id == id);
            return user;
        }
    }
}
