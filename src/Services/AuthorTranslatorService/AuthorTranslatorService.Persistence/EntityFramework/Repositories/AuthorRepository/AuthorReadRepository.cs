using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AuthorTranslatorService.Persistence.EntityFramework.Context;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorRepository
{
    public class AuthorReadRepository : EfReadRepository<Author, AuthorTranslatorServiceContext>, IAuthorReadRepository
    {
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
