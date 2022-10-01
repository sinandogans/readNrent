using AutoMapper;
using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using MediatR;

namespace BookService.Application.Features.Translators.Commands.UpdateTranslatorCommand
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

            return new UpdateTranslatorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
