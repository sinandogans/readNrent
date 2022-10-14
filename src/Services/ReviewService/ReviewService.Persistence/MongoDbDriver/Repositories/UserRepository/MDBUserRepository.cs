using ReviewService.Application.Abstraction.Persistence.UserRepository;
using ReviewService.Domain.Entities;
using ReviewService.Persistence.MongoDbDriver.Context;
using ReviewService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace ReviewService.Persistence.MongoDbDriver.Repositories.UserRepository
{
    public class MDBUserRepository : MDBBaseRepository<User>, IUserRepository
    {
        private readonly MongoDbContext _context;

        public MDBUserRepository(MongoDbContext context) : base(context.UsersCollection)
        {
            _context = context;
        }
        public async Task<User> GetById(Guid id)
        {
            var user = await Get(a => a.Id == id);
            return user;
        }
    }
}
