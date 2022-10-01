using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryRequest : IRequest<GetAllAuthorsQueryResponse>
    {
    }
}
