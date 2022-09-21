namespace BookService.Application.Features.Books.Commands.AddBookImageCommand
{
    public class AddBookImageCommandResponse
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid BookId { get; set; }
    }
}
