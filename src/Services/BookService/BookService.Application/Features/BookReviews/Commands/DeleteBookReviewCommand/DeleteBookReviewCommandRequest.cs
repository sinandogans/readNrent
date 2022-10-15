using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand
{
    public class DeleteBookReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
}
