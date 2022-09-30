using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using MongoDB.Driver;

namespace AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.TranslatorReviewRepository
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
                await this.Delete(id);
        }

        public async Task<List<TranslatorReview>> GetByTranslatorId(Guid translatorId)
        {
            var reviews = await this.GetList(r => r.TranslatorId == translatorId);
            return reviews;
        }

        public async Task<TranslatorReview> GetById(Guid id)
        {
            var review = await this.Get(r => r.Id == id);
            return review;
        }
    }
}
