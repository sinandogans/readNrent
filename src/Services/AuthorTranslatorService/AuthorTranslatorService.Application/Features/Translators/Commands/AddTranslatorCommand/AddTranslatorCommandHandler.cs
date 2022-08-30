using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand
{
    public class AddTranslatorCommandHandler : IRequestHandler<AddTranslatorCommandRequest, AddTranslatorCommandResponse>
    {
        private readonly ITranslatorWriteRepository _repository;
        private readonly IMapper _mapper;

        public AddTranslatorCommandHandler(ITranslatorWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddTranslatorCommandResponse> Handle(AddTranslatorCommandRequest request, CancellationToken cancellationToken)
        {
            var translatorToAdd = _mapper.Map<Translator>(request);
            translatorToAdd.Id = Guid.NewGuid();
            translatorToAdd.Rating = 0;
            translatorToAdd.ReviewCount = 0;

            await _repository.Add(translatorToAdd);

            var response = _mapper.Map<AddTranslatorCommandResponse>(translatorToAdd);
            return response;
        }
    }
}
