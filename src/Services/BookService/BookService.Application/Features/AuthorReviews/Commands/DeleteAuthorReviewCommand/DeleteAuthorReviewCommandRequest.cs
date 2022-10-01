using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandRequest : IRequest<DeleteAuthorReviewCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
