using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand
{
    public class AddTranslatorCommandHandler : IRequestHandler<AddTranslatorCommandRequest, AddTranslatorCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public AddTranslatorCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<AddTranslatorCommandResponse> Handle(AddTranslatorCommandRequest request, CancellationToken cancellationToken)
        {
            var translatorToAdd = _mapper.Map<Translator>(request);
            translatorToAdd.Id = Guid.NewGuid();

            await _translatorRepository.Add(translatorToAdd);

            var response = _mapper.Map<AddTranslatorCommandResponse>(translatorToAdd);
            return response;
        }
    }
}
