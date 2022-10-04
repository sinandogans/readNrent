using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandRequest : IRequest<AddAuthorReviewCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid AuthorId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
