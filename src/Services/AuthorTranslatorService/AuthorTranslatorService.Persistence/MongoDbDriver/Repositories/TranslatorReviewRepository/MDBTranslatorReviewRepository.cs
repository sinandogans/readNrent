using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using Microsoft.Extensions.Options;
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
    }
}
