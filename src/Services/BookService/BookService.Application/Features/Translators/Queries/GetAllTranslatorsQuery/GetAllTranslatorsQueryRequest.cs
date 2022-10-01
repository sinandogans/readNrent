using MediatR;

namespace BookService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryRequest : IRequest<GetAllTranslatorsQueryResponse>
    {
    }
}
