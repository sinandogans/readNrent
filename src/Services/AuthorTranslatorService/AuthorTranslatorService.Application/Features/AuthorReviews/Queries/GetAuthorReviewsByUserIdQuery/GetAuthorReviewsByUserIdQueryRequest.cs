using AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByAuthorIdQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByUserIdQuery
{
    public class GetAuthorReviewsByUserIdQueryRequest : IRequest<List<GetAuthorReviewsByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
