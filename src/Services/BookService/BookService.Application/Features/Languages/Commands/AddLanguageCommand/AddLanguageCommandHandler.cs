using AutoMapper;
using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Languages.Commands.AddLanguageCommand
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommandRequest, IResponseModel>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public AddLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(AddLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var languageToAdd = _mapper.Map<Language>(request);
            languageToAdd.Id = Guid.NewGuid();
            await _languageRepository.Add(languageToAdd);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
