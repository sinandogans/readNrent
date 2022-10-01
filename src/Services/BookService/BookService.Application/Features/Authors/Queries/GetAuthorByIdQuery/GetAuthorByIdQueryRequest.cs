using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryRequest : IRequest<GetAuthorByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
