using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
