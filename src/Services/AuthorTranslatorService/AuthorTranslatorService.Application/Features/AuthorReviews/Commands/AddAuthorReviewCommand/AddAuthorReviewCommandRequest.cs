using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandRequest : IRequest<AddAuthorReviewCommandResponse>
    {
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid AuthorId { get; set; }
        public Guid UserId { get; set; }
    }
}
