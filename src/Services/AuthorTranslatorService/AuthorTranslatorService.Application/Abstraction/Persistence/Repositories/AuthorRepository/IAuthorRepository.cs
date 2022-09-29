using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<List<AuthorReview>> GetReviews(Guid id);
        Task AddReview(AuthorReview review);
        Task DeleteReview(Guid reviewId);
        Task DeleteReviews(List<Guid> reviewIds);
        Task<Author> GetById(Guid id);
        Task<Author> GetByReviewId(Guid reviewId);
        Task<AuthorReview> GetReviewById(Guid id);
        Task UpdateReview(AuthorReview review);
    }
}
