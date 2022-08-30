using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByUserIdQuery
{
    public class GetTranslatorReviewsByUserIdQueryRequest : IRequest<List<GetTranslatorReviewsByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
