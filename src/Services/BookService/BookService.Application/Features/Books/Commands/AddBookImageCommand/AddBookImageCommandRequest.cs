using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookImageCommand
{
    public class AddBookImageCommandRequest : IRequest<AddBookImageCommandResponse>
    {
    }
    public class AddBookImageCommandHandler : IRequestHandler<AddBookImageCommandRequest, AddBookImageCommandResponse>
    {
        public Task<AddBookImageCommandResponse> Handle(AddBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class AddBookImageCommandResponse
    {
    }
}
