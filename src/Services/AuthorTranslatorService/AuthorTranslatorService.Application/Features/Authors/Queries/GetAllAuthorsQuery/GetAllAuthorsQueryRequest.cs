using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryRequest : IRequest<List<GetAllAuthorsQueryResponse>>
    {
    }
}
