using MediatR;

namespace BookService.Application.Features.Authors.Commands.AddAuthorCommand
{
    public class AddAuthorCommandRequest : IRequest<AddAuthorCommandResponse>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
