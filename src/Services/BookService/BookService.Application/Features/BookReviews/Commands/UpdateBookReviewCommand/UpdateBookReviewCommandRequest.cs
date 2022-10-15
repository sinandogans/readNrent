using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
    }
}
