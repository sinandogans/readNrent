using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
}
