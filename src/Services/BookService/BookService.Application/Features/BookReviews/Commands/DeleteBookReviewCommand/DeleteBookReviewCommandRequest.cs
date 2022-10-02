using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand
{
    public class DeleteBookReviewCommandRequest : IRequest<DeleteBookReviewCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
