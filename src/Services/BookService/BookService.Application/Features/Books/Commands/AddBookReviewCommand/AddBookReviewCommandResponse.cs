namespace BookService.Application.Features.Books.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
