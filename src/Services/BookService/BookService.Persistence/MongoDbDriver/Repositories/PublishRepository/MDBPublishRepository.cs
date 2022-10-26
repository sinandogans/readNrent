using BookService.Application.Abstraction.Persistence.PublishRepository;
using BookService.Domain.AggregatesModel.BookAggregate;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.PublishRepository
{
    public class MDBPublishRepository : MDBBaseRepository<Publish>, IPublishRepository
    {
        private readonly MongoDbContext _context;
        public MDBPublishRepository(MongoDbContext context) : base(context.PublishesCollection)
        {
            _context = context;
        }
    }
}
