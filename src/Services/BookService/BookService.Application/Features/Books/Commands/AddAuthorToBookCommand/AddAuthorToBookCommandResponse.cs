namespace BookService.Application.Features.Books.Commands.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommandResponse
    {
        public Guid Id { get; set; }
        public List<AuthorModel> Authors { get; set; }
    }
}
