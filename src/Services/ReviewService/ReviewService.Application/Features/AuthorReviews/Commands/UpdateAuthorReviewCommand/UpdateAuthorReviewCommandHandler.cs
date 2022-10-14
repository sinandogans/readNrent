using MediatR;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;

namespace ReviewService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateAuthorReviewCommandRequest, UpdateAuthorReviewCommandResponse>
    {
        private readonly IAuthorReviewRepository _authorReviewRepository;

        public UpdateBookReviewCommandHandler(IAuthorReviewRepository authorReviewRepository)
        {
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<UpdateAuthorReviewCommandResponse> Handle(UpdateAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _authorReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            {
                reviewToUpdate.Rating = (double)request.Rating;
            }

            await _authorReviewRepository.Update(reviewToUpdate);

            return new UpdateAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
