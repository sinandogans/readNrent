using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookPublishCommand
{
    public class AddBookPublishCommandRequest : IRequest<AddBookPublishCommandResponse>
    {
        public Guid PublisherId { get; set; }
        public Guid BookId { get; set; }
    }
}
