using AutoMapper;
using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Languages.Commands.AddLanguageCommand
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommandRequest, AddLanguageCommandResponse>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public AddLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<AddLanguageCommandResponse> Handle(AddLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var languageToAdd = _mapper.Map<Language>(request);
            languageToAdd.Id = Guid.NewGuid();
            await _languageRepository.Add(languageToAdd);
            var response = _mapper.Map<AddLanguageCommandResponse>(languageToAdd);
            return response;
        }
    }
}
