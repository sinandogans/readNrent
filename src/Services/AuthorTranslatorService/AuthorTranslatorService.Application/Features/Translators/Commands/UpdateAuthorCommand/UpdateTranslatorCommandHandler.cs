using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateTranslatorCommandHandler : IRequestHandler<UpdateTranslatorCommandRequest, UpdateTranslatorCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public UpdateTranslatorCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTranslatorCommandResponse> Handle(UpdateTranslatorCommandRequest request, CancellationToken cancellationToken)
        {
            var translatorToUpdate = await _translatorRepository.GetById(request.Id);
            if (request.Firstname != null)
                translatorToUpdate.Firstname = request.Firstname;
            if (request.Lastname != null)
                translatorToUpdate.Lastname = request.Lastname;

            await _translatorRepository.Update(translatorToUpdate);
            return _mapper.Map<UpdateTranslatorCommandResponse>(translatorToUpdate);
        }
    }
}
