using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorReviewCommand
{
    public class DeleteTranslatorReviewCommandHandler : IRequestHandler<DeleteTranslatorReviewCommandRequest, DeleteTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public DeleteTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<DeleteTranslatorReviewCommandResponse> Handle(DeleteTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _translatorRepository.GetReviewById(request.Id);
            await _translatorRepository.DeleteReview(request.Id);

            var translator = await _translatorRepository.GetByReviewId(request.Id);
            translator.Rating = ((translator.Rating * translator.ReviewCount) - review.Rating) / (translator.ReviewCount - 1);
            translator.ReviewCount--;
            translator.ReviewIds.Remove(review.Id);
            await _translatorRepository.Update(translator);

            return new DeleteTranslatorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
