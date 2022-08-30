using AuthorTranslatorService.Domain.Entities;
using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByAuthorIdQuery
{
    public class GetAuthorReviewsByAuthorIdQueryRequest : IRequest<List<GetAuthorReviewsByAuthorIdQueryResponse>>
    {
        public Guid AuthorId { get; set; }
    }
}
