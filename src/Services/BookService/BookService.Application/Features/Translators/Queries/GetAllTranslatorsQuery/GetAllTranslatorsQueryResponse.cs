using BookService.Application.Features.Translators.DTOs;
using BookService.Application.Utilities.ResponseModel;

namespace BookService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryResponse : DataResponse<List<GetTranslatorDTO>>
    {
    }
}
