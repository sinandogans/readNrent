using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Comment { get; set; }
    }
}
