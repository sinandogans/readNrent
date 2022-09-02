using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookGenreCommand
{
    public class AddBookGenreCommandRequest : IRequest<AddBookGenreCommandResponse>
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
    }
}
