using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByTranslatorIdQuery
{
    public class GetTranslatorReviewsByTranslatorIdQueryRequest : IRequest<List<GetTranslatorReviewsByTranslatorIdQueryResponse>>
    {
        public Guid TranslatorId { get; set; }
    }
}
