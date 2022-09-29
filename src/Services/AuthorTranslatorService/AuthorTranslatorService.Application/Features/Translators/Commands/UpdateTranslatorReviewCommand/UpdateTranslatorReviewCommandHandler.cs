using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorReviewCommand
{
    public class UpdateTranslatorReviewCommandHandler : IRequestHandler<UpdateTranslatorReviewCommandRequest, UpdateTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;

        public UpdateTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;
        }

        public async Task<UpdateTranslatorReviewCommandResponse> Handle(UpdateTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _translatorRepository.GetReviewById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            {
                var translator = await _translatorRepository.GetByReviewId(request.Id);
                translator.Rating = ((translator.Rating * translator.ReviewCount) - reviewToUpdate.Rating + (double)request.Rating) / (translator.ReviewCount);
                await _translatorRepository.Update(translator);
                reviewToUpdate.Rating = (double)request.Rating;
            }

            await _translatorRepository.UpdateReview(reviewToUpdate);

            return new UpdateTranslatorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
