using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByUserIdQuery
{
    public class GetAuthorReviewsByUserIdQueryRequest : IRequest<List<GetAuthorReviewsByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
