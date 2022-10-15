using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateAuthorReviewCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
