using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandRequest : IRequest<AddBookCommandResponse>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
    }
}
