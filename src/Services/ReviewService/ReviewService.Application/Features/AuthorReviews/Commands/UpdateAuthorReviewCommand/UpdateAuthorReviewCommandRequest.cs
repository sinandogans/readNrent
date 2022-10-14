using Core.Utilities.Results;
using MediatR;

namespace ReviewService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateAuthorReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
