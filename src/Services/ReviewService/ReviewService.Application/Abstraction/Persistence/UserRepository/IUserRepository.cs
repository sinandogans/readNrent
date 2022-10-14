using ReviewService.Application.Abstraction.Persistence.BaseRepository;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Abstraction.Persistence.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(Guid id);
    }
}
