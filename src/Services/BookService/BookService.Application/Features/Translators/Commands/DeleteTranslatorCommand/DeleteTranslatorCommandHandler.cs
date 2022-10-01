using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using BookService.Application.Abstraction.Persistence.TranslatorReviewRepository;
using MediatR;

namespace BookService.Application.Features.Translators.Commands.DeleteTranslatorCommand
{
    public class DeleteTranslatorCommandHandler : IRequestHandler<DeleteTranslatorCommandRequest, DeleteTranslatorCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ITranslatorReviewRepository _translatorReviewRepository;

        public DeleteTranslatorCommandHandler(ITranslatorRepository translatorRepository, ITranslatorReviewRepository translatorReviewRepository)
        {
            _translatorRepository = translatorRepository;
            _translatorReviewRepository = translatorReviewRepository;
        }

        public async Task<DeleteTranslatorCommandResponse> Handle(DeleteTranslatorCommandRequest request, CancellationToken cancellationToken)
        {
            var translator = await _translatorRepository.GetById(request.Id);
            await _translatorReviewRepository.DeleteList(translator.ReviewIds.ToList());

            await _translatorRepository.Delete(request.Id);

            return new DeleteTranslatorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
