using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Domain.AggregatesModel.UserAggregate;
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
        public async Task<User> GetById(Guid id)
        {
            var user = await Get(a => a.Id == id);
            return user;
        }

        public async Task AddUserBook(UserBook book)
        {
            throw new NotImplementedException();
        }
    }
}
