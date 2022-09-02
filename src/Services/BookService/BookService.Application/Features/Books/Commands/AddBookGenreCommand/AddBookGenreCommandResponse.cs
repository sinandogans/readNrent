using BookService.Domain.Entities;

namespace BookService.Application.Features.Books.Commands.AddBookGenreCommand
{
    public class AddBookGenreCommandResponse
    {
        public Guid Id { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
