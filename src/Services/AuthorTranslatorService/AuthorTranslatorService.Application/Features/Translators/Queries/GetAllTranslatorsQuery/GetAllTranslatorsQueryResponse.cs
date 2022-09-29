using AuthorTranslatorService.Application.Features.ResponseModel;
using AuthorTranslatorService.Application.Features.Translators.DTOs;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryResponse : DataResponse<List<GetTranslatorDTO>>
    {
    }
}
