using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorRepository
{
    public class EFTranslatorRepository : EFBaseRepository<Translator, AuthorTranslatorServiceContext>, ITranslatorRepository
    {
        public async Task AddReview(TranslatorReview review)
        {
            using (DbContext context = new AuthorTranslatorServiceContext())
            {
                await context.Set<TranslatorReview>().AddAsync(review);

                var translator = await context.Set<Translator>().SingleOrDefaultAsync(a => a.Id == review.TranslatorId);
                translator.Rating = ((translator.Rating * translator.ReviewCount) + review.Rating) / (translator.ReviewCount + 1);
                translator.ReviewCount++;
                await context.SaveChangesAsync();
            }
        }
    }
}
