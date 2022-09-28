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
            await _translatorRepository.Delete(request.Id);
            return new DeleteTranslatorCommandResponse();
        }
    }
}
