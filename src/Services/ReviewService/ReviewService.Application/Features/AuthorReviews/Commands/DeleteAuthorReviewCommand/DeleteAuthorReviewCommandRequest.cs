using Core.Utilities.Results;
using MediatR;

namespace ReviewService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
}
