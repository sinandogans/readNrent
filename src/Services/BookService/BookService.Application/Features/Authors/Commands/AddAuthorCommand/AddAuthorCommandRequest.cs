using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Enums;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.AddAuthorCommand
{
    public class AddAuthorCommandRequest : IRequest<IResponseModel>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public AuthorType Type { get; set; }
    }
}
