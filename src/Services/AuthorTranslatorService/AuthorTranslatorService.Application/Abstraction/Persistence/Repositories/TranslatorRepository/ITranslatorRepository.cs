using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.BaseRepository;
using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository
{
    public interface ITranslatorRepository : IBaseRepository<Translator>
    {
        //Task<List<TranslatorReview>> GetReviews(Guid id);
        //Task AddReview(TranslatorReview review);
        //Task DeleteReview(Guid reviewId);
        //Task DeleteReviews(List<Guid> reviewIds);
        Task<Translator> GetById(Guid id);
        Task<Translator> GetByReviewId(Guid reviewId);
        //Task<TranslatorReview> GetReviewById(Guid id);
        //Task UpdateReview(TranslatorReview review);
    }
}
