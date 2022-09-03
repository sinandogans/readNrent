using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.EntityFramework.Contexts;
using IdentityService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.EntityFramework.Repositories.UserRepository
{
    public class EfUserReadRepository : EfBaseReadRepository<User, IdentityServiceContext>, IUserReadRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            var user = await this.Get(u => u.Email == email);
            return user;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await this.Get(u => u.Id == id);
            return user;
        }

        public async Task<List<RoleClaim>> GetRoleClaims(Guid userId)
        {
            using (IdentityServiceContext context = new IdentityServiceContext())
            {
                var user = await context.Set<User>().Include(u => u.RoleClaims).SingleOrDefaultAsync(u => u.Id == userId);
                return user.RoleClaims.ToList();
            }

        }
    }
}
