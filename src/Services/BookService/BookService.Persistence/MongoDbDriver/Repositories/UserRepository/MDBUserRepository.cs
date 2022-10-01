using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.UserRepository
{
    public class MDBUserRepository : MDBBaseRepository<User>, IUserRepository
    {
        private readonly MongoDbContext _context;

        public MDBUserRepository(MongoDbContext context) : base(context.UsersCollection)
        {
            _context = context;
        }
    }
}
