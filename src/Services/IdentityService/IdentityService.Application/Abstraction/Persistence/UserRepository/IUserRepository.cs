using IdentityService.Application.Abstraction.Persistence.BaseRepository;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction.Persistence.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task<List<RoleClaim>> GetRoleClaims(Guid userId);
    }
}
