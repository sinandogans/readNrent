using MediatR;

namespace BookService.Application.Features.Books.Commands.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommandRequest : IRequest<AddAuthorToBookCommandResponse>
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
