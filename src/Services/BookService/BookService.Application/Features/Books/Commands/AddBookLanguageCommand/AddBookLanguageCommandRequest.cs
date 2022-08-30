using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookLanguageCommand
{
    public class AddBookLanguageCommandRequest : IRequest<AddBookLanguageCommandResponse>
    {
        public Guid LanguageId { get; set; }
        public Guid BookId { get; set; }
    }
}
