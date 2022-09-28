using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.AuthorReviewRepository
{
    public class MDBAuthorReviewRepository : MDBBaseRepository<AuthorReview>, IAuthorReviewRepository
    {
        private readonly MongoDbContext _context;

        public MDBAuthorReviewRepository(MongoDbContext context) : base(context.AuthorReviewsCollection)
        {
            _context = context;
        }
    }
}
