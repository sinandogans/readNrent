using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.PublisherRepository
{
    public class MDBPublisherRepository : MDBBaseRepository<Publisher>, IPublisherRepository
    {
        private readonly MongoDbContext _context;
        public MDBPublisherRepository(MongoDbContext context) : base(context.PublishersCollection)
        {
            _context = context;
        }

        public async Task<Publisher> GetById(Guid id)
        {
            var publisher = await this.Get(r => r.Id == id);
            return publisher;
        }
    }
}
