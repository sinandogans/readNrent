using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorCommand
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
            await _translatorReviewRepository.DeleteList(translator.ReviewIds);

            await _translatorRepository.Delete(request.Id);

            return new DeleteTranslatorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
