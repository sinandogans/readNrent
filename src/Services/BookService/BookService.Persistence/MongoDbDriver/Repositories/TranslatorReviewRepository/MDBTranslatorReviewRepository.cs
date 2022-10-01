using BookService.Application.Abstraction.Persistence.TranslatorReviewRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;

namespace BookService.Persistence.MongoDbDriver.Repositories.TranslatorReviewRepository
{
    public class MDBTranslatorReviewRepository : MDBBaseRepository<TranslatorReview>, ITranslatorReviewRepository
    {
        private readonly MongoDbContext _context;

        public MDBTranslatorReviewRepository(MongoDbContext context) : base(context.TranslatorReviewsCollection)
        {
            _context = context;
        }

        public async Task DeleteList(List<Guid> ids)
        {
            foreach (var id in ids)
                await Delete(id);
        }

        public async Task<List<TranslatorReview>> GetByTranslatorId(Guid translatorId)
        {
            var reviews = await GetList(r => r.TranslatorId == translatorId);
            return reviews;
        }

        public async Task<TranslatorReview> GetById(Guid id)
        {
            var review = await Get(r => r.Id == id);
            return review;
        }
    }
}
