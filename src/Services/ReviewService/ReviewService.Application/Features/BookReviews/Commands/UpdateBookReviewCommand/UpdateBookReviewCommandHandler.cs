using Core.Utilities.Results;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;

namespace ReviewService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateBookReviewCommandRequest, IResponseModel>
    {
        private readonly IBookReviewRepository _bookReviewRepository;

        public UpdateBookReviewCommandHandler(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<IResponseModel> Handle(UpdateBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _bookReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }

            await _bookReviewRepository.Update(reviewToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
