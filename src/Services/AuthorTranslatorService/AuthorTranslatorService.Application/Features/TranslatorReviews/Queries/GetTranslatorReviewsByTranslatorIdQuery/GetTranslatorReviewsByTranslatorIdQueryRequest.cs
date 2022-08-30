using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByTranslatorIdQuery
{
    public class GetTranslatorReviewsByTranslatorIdQueryRequest : IRequest<List<GetTranslatorReviewsByTranslatorIdQueryResponse>>
    {
        public Guid TranslatorId { get; set; }
    }
}
