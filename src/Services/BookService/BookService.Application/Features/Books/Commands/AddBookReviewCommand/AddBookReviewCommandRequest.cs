using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandRequest : IRequest<AddBookReviewCommandResponse>
    {
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
