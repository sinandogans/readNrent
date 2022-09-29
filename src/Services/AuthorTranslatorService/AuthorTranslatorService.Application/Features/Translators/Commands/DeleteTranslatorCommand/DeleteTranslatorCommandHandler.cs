using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorCommand
{
    public class DeleteTranslatorCommandHandler : IRequestHandler<DeleteTranslatorCommandRequest, DeleteTranslatorCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;

        public DeleteTranslatorCommandHandler(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;
        }

        public async Task<DeleteTranslatorCommandResponse> Handle(DeleteTranslatorCommandRequest request, CancellationToken cancellationToken)
        {
            var translator = await _translatorRepository.GetById(request.Id);
            await _translatorRepository.DeleteReviews(translator.ReviewIds);

            await _translatorRepository.Delete(request.Id);

            return new DeleteTranslatorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
