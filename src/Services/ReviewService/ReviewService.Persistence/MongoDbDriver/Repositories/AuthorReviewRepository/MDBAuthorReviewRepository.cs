using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;
using ReviewService.Domain.Entities;
using ReviewService.Persistence.MongoDbDriver.Context;
using ReviewService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace ReviewService.Persistence.MongoDbDriver.Repositories.AuthorReviewRepository
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
                await Delete(id);
        }

        public async Task<List<AuthorReview>> GetByAuthorId(Guid authorId)
        {
            var reviews = await GetList(r => r.AuthorId == authorId);
            return reviews;
        }

        public async Task<AuthorReview> GetById(Guid id)
        {
            var review = await Get(r => r.Id == id);
            return review;
        }
    }
}
