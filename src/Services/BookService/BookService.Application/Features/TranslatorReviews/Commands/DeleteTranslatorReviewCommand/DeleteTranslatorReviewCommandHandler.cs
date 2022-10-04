using AutoMapper;
using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using BookService.Application.Abstraction.Persistence.TranslatorReviewRepository;
using MediatR;

namespace BookService.Application.Features.TranslatorReviews.Commands.DeleteTranslatorReviewCommand
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
            translator.Feature.Rating = (translator.Feature.Rating * translator.Feature.ReviewCount - review.Rating) / (translator.Feature.ReviewCount - 1);
            translator.Feature.ReviewCount--;
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
