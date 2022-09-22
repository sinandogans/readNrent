using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorRepository
{
    public class EFAuthorRepository : EFBaseRepository<Author, AuthorTranslatorServiceContext>, IAuthorRepository
    {
        public async Task AddReview(AuthorReview review)
        {
            using (DbContext context = new AuthorTranslatorServiceContext())
            {
                await context.Set<AuthorReview>().AddAsync(review);

                var author = await context.Set<Author>().SingleOrDefaultAsync(a => a.Id == review.AuthorId);
                author.Rating = ((author.Rating * author.ReviewCount) + review.Rating) / (author.ReviewCount + 1);
                author.ReviewCount++;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<AuthorReview>> GetAuthorReviews(Guid id)
        {
            using (DbContext context = new AuthorTranslatorServiceContext())
            {
                var author = await context.Set<Author>().Where(a => a.Id == id).Include(a => a.Reviews).SingleOrDefaultAsync();
                return author.Reviews.ToList();
            }
        }
    }
}
