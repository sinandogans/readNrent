using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetTranslatorByIdQuery
{
    public class GetTranslatorByIdQueryRequest : IRequest<GetTranslatorByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
