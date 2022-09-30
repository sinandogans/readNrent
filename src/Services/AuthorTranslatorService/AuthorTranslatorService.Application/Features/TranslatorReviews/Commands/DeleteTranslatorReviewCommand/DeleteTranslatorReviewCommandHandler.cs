using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorReviewCommand
{
    public class DeleteTranslatorReviewCommandHandler : IRequestHandler<DeleteTranslatorReviewCommandRequest, DeleteTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ITranslatorReviewRepository _translatorReviewRepository;
        private readonly IMapper _mapper;

        public DeleteTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper, ITranslatorReviewRepository translatorReviewRepository)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
            _translatorReviewRepository = translatorReviewRepository;
        }

        public async Task<DeleteTranslatorReviewCommandResponse> Handle(DeleteTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _translatorReviewRepository.GetById(request.Id);
            await _translatorReviewRepository.Delete(request.Id);

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
