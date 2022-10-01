using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.AuthorReviewRepository
{
    public class MDBAuthorReviewRepository : MDBBaseRepository<AuthorReview>, IAuthorReviewRepository
    {
        private readonly MongoDbContext _context;

        public MDBAuthorReviewRepository(MongoDbContext context) : base(context.AuthorReviewsCollection)
        {
            _context = context;
        }

        public async Task DeleteList(List<Guid> ids)
        {
            foreach (var id in ids)
                await this.Delete(id);
        }

        public async Task<List<AuthorReview>> GetByAuthorId(Guid authorId)
        {
            var reviews = await this.GetList(r => r.AuthorId == authorId);
            return reviews;
        }

        public async Task<AuthorReview> GetById(Guid id)
        {
            var review = await this.Get(r => r.Id == id);
            return review;
        }
    }
}
