using IdentityService.Application.Abstraction.Persistence.BaseRepository;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Abstraction.Persistence.RoleClaimRepository
{
    public interface IRoleClaimReadRepository : IBaseReadRepository<RoleClaim>
    {
        Task<RoleClaim> GetById(Guid id);
    }
}
