using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using BookService.Domain.Entities;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.BaseRepository;
using Microsoft.Extensions.Options;

namespace BookService.Persistence.MongoDbDriver.Repositories.TranslatorRepository
{
    public class MDBTranslatorRepository : MDBBaseRepository<Translator>, ITranslatorRepository
    {
        private readonly MongoDbContext _context;


        public MDBTranslatorRepository(IOptions<MongoDbOptions> dbOptions, MongoDbContext context) : base(context.TranslatorsCollection)
        {
            _context = context;
        }

        public async Task<Translator> GetById(Guid id)
        {
            var translator = await Get(a => a.Id == id);
            return translator;
        }

        public async Task<Translator> GetByReviewId(Guid reviewId)
        {
            var translator = await Get(a => a.ReviewIds.Contains(reviewId));
            return translator;
        }
    }
}
