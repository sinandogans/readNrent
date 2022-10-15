using BookService.Application.Features.Authors.DTOs;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryRequest : IRequest<IDataResponseModel<GetAuthorDTO>>
    {
        public Guid Id { get; set; }
    }
}
