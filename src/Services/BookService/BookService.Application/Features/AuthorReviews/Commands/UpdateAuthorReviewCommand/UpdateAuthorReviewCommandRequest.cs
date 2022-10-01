using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateAuthorReviewCommandRequest : IRequest<UpdateAuthorReviewCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
