using Core.Utilities.Results;
using MediatR;

namespace ReviewService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid AuthorId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
