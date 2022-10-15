using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
}
