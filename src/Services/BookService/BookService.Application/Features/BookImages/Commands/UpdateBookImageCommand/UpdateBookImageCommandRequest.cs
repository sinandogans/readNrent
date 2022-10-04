using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookImages.Commands.UpdateBookImageCommand
{
    public class UpdateBookImageCommandRequest : IRequest<UpdateBookImageCommandResponse>
    {
    }
    public class UpdateBookImageCommandHandler : IRequestHandler<UpdateBookImageCommandRequest, UpdateBookImageCommandResponse>
    {
        public Task<UpdateBookImageCommandResponse> Handle(UpdateBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class UpdateBookImageCommandResponse : Response
    {
    }
}
