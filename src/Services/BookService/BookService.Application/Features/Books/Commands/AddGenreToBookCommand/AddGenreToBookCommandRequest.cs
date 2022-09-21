using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookGenreCommand
{
    public class AddGenreToBookCommandRequest : IRequest<AddGenreToBookCommandResponse>
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
    }
}
