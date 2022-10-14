using MediatR;

namespace ReviewService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandRequest : IRequest<UpdateBookReviewCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
    }
}
