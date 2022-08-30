using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByUserIdQuery
{
    public class GetTranslatorReviewsByUserIdQueryRequest : IRequest<List<GetTranslatorReviewsByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
