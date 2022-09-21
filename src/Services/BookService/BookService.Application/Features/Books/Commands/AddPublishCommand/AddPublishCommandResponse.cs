namespace BookService.Application.Features.Books.Commands.AddBookPublishCommand
{
    public class AddPublishCommandResponse
    {
        public Guid Id { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid PublisherId { get; set; }
        public Guid BookId { get; set; }
    }
}
