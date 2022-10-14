using Core.Utilities.Results;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;

namespace ReviewService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateAuthorReviewCommandRequest, IResponseModel>
    {
        private readonly IAuthorReviewRepository _authorReviewRepository;

        public UpdateBookReviewCommandHandler(IAuthorReviewRepository authorReviewRepository)
        {
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<IResponseModel> Handle(UpdateAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _authorReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            await _authorReviewRepository.Update(reviewToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
