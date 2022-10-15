using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookImages.Commands.UpdateBookImageCommand
{
    public class UpdateBookImageCommandRequest : IRequest<IResponseModel>
    {
    }
    public class UpdateBookImageCommandHandler : IRequestHandler<UpdateBookImageCommandRequest, IResponseModel>
    {
        public Task<IResponseModel> Handle(UpdateBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
