using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryRequest : IRequest<GetAllTranslatorsQueryResponse>
    {
    }
}
