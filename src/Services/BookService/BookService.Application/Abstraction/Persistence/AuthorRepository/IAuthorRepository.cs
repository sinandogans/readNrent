using BookService.Application.Abstraction.Persistence.BaseRepository;
using BookService.Domain.Entities;

namespace BookService.Application.Abstraction.Persistence.AuthorRepository
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        //Task<List<AuthorReview>> GetReviews(Guid id);
        //Task AddReview(AuthorReview review);
        //Task DeleteReview(Guid reviewId);
        //Task DeleteReviews(List<Guid> reviewIds);
        Task<Author> GetById(Guid id);
        Task<Author> GetByReviewId(Guid reviewId);
        //Task<AuthorReview> GetReviewById(Guid id);
        //Task UpdateReview(AuthorReview review);
    }
}
