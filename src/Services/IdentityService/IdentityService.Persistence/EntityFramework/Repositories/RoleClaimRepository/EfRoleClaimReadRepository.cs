using IdentityService.Application.Abstraction.Persistence.RoleClaimRepository;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.EntityFramework.Contexts;
using IdentityService.Persistence.EntityFramework.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Persistence.EntityFramework.Repositories.RoleClaimRepository
{
    public class EfRoleClaimReadRepository : EfBaseReadRepository<RoleClaim, IdentityServiceContext>, IRoleClaimReadRepository
    {
        public async Task<RoleClaim> GetById(Guid id)
        {
            var user = await this.Get(u => u.Id == id);
            return user;
        }
    }
}
