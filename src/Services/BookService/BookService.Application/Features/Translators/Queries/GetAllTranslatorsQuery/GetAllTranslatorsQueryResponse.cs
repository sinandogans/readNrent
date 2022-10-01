using BookService.Application.Features.ResponseModel;
using BookService.Application.Features.Translators.DTOs;

namespace BookService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryResponse : DataResponse<List<GetTranslatorDTO>>
    {
    }
}
