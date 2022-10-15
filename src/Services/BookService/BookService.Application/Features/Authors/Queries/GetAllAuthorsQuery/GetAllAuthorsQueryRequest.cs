using BookService.Application.Features.Authors.DTOs;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryRequest : IRequest<IDataResponseModel<List<GetAuthorDTO>>>
    {
    }
}
