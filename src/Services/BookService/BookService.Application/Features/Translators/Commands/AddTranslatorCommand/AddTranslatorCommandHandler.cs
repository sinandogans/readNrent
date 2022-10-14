using AutoMapper;
using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Translators.Commands.AddTranslatorCommand
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
            var feature = _mapper.Map<Translator>(request);
            var translatorToAdd = new Translator();
            translatorToAdd.Id = Guid.NewGuid();
            translatorToAdd = feature;

            await _translatorRepository.Add(translatorToAdd);

            return new AddTranslatorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
