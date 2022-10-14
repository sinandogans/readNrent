using Core.Utilities.Results;
using MediatR;

namespace ReviewService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand
{
    public class DeleteBookReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
}
