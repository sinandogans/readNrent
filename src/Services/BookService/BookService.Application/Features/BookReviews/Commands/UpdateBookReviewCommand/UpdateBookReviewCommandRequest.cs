using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandRequest : IRequest<UpdateBookReviewCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
