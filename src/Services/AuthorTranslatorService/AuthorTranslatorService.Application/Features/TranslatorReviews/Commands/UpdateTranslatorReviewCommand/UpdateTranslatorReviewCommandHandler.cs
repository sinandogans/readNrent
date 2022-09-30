using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorReviewCommand
{
    public class UpdateTranslatorReviewCommandHandler : IRequestHandler<UpdateTranslatorReviewCommandRequest, UpdateTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ITranslatorReviewRepository _translatorReviewRepository;

        public UpdateTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository, ITranslatorReviewRepository translatorReviewRepository)
        {
            _translatorRepository = translatorRepository;
            _translatorReviewRepository = translatorReviewRepository;
        }

        public async Task<UpdateTranslatorReviewCommandResponse> Handle(UpdateTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _translatorReviewRepository.GetById(request.Id);
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

            await _translatorReviewRepository.Update(reviewToUpdate);

            return new UpdateTranslatorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
