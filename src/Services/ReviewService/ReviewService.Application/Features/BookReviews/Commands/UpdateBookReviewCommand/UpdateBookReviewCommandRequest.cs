using Core.Utilities.Results;
using MediatR;

namespace ReviewService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
    }
}
